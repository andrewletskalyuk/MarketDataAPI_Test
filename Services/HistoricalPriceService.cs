using AutoMapper;
using MarketDataAPI.Data;
using MarketDataAPI.Data.Entities;
using MarketDataAPI.Dtos;
using MarketDataAPI.Models.AssetsModels;
using MarketDataAPI.Wrapper;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MarketDataAPI.Services;

public class HistoricalPriceService : IHistoricalPriceService
{
    readonly IMapper _mapper;
    readonly HttpClient _httpClient;
    readonly IConfiguration _configuration;
    readonly IAuthService _authService;
    readonly ApplicationDbContext _context;

    public HistoricalPriceService(HttpClient httpClient, IConfiguration configuration,
        IAuthService authService, IMapper mapper, ApplicationDbContext context)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _authService = authService;
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<HistoricalPriceResponse>> GetHistoricalPricesAsync(HistoricalPriceDto historicalPriceDto)
    {
        var responseList = new List<HistoricalPriceResponse>();

        var token = await _authService.GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedAccessException("Unable to obtain token.");
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var provider = "oanda";
        var interval = "1";
        var periodicity = "minute";
        var endDate = DateTime.UtcNow;
        foreach (var instrumentId in historicalPriceDto.InstrumentIds)
        {
            var uri = $"{_configuration["Fintacharts:URI"]}/api/bars/v1/bars/date-range?" +
                  $"instrumentId={0}&provider={provider}&interval={interval}&periodicity={periodicity}&startDate={historicalPriceDto.startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

            try
            {
                var response = await _httpClient.GetAsync(uri);

                var responseBody = await response.Content.ReadAsStringAsync();
                var priceDataList = JsonSerializer.Deserialize<List<PriceData>>(responseBody,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                var historicalPriceResponse = new HistoricalPriceResponse
                {
                    InstrumentId = instrumentId,
                    Prices = priceDataList ?? new List<PriceData>()
                };

                responseList.Add(historicalPriceResponse);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }

        return responseList;
    }

    public async Task<List<InstrumentDto>> GetInstrumentsAsync()
    {
        var token = await _authService.GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedAccessException("Unable to obtain token.");
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var uri = $"{_configuration["Fintacharts:URI"]}/api/instruments/v1/instruments?provider=oanda&kind=forex";

        var response = await _httpClient.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            try
            {
                var instrumentResponse = JsonSerializer.Deserialize<InstrumentResponse>(jsonResponse,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                var instrumentDtos = _mapper.Map<List<InstrumentDto>>(instrumentResponse?.Data);

                //Add instuments first time if DB empty
                var instruments = _mapper.Map<List<Instrumenty>>(instrumentResponse?.Data);

                var full = _context.Instruments.Any();

                if (!full)
                {
                    _context.Instruments.AddRange(instruments);
                    await _context.SaveChangesAsync();
                }

                return instrumentDtos ?? new List<InstrumentDto>();
            }
            catch (JsonException ex)
            {
                throw;
            }
        }
        else
        {
            throw new HttpRequestException($"Error fetching instruments: {response.StatusCode}");
        }
    }
}
