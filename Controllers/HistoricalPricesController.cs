using MarketDataAPI.Data.Entities;
using MarketDataAPI.Dtos;
using MarketDataAPI.Models;
using MarketDataAPI.Models.AssetsModels;
using MarketDataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketDataAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoricalPricesController : BaseApiController
{
    private readonly IHistoricalPriceService _historicalPriceService;

    public HistoricalPricesController(IHistoricalPriceService historicalPriceService)
    {
        _historicalPriceService = historicalPriceService;
    }

    [HttpPost("historicalPrice")]
    public async Task<IActionResult> GetHistoricalPrices([FromBody] HistoricalPriceDto historicalPriceDto)
    {
        var result = await _historicalPriceService.GetHistoricalPricesAsync(historicalPriceDto);
        return HandleResult(Result<List<HistoricalPriceResponse>>.Success(result));
    }

    [HttpGet("instruments")]
    public async Task<ActionResult<IEnumerable<Instrumenty>>> GetInstruments()
    {
        var instruments = await _historicalPriceService.GetInstrumentsAsync();
        return Ok(instruments);
    }
}
