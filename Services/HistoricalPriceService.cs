using MarketDataAPI.Models;
using MarketDataAPI.Models.InstrumentsClasses;
using System.Net.Http.Headers;

namespace MarketDataAPI.Services;

public class HistoricalPriceService : IHistoricalPriceService
{
    readonly HttpClient _httpClient;
    readonly IConfiguration _configuration;
    readonly IAuthService _authService;

    public HistoricalPriceService(HttpClient httpClient, IConfiguration configuration, IAuthService authService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _authService = authService;
    }

    public async Task<List<PriceData>> GetHistoricalPricesAsync(string instrumentId, DateTime startDate, DateTime endDate)
    {
        var uri = $"{_configuration["Fintacharts:URI"]}/api/bars/v1/bars/date-range?instrumentId={instrumentId}&startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
        var response = await _httpClient.GetFromJsonAsync<List<PriceData>>(uri);

        if (response !=null)
        {
            return response;
        }
        return new List<PriceData>();
    }

    public async Task<List<Instrumenty>> GetInstrumentsAsync()
    {
        var token = await _authService.GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedAccessException("Unable to obtain token.");
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var uri = $"{_configuration["Fintacharts:URI"]}/api/instruments/v1/instruments?provider=oanda&kind=forex";

        var response = await _httpClient.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        return new List<Instrumenty>();
    }
}
