using MarketDataAPI.Models;
using MarketDataAPI.Models.InstrumentsClasses;
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

    [HttpGet("{instrumentId}")]
    public async Task<IActionResult> GetHistoricalPrices(string instrumentId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _historicalPriceService.GetHistoricalPricesAsync(instrumentId, startDate, endDate);
        return HandleResult(Result<List<PriceData>>.Success(result));
    }

    [HttpGet("instruments")]
    public async Task<ActionResult<IEnumerable<Instrumenty>>> GetInstruments()
    {
        var instruments = await _historicalPriceService.GetInstrumentsAsync();
        return Ok(instruments);
    }
}
