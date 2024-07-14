using Microsoft.AspNetCore.Mvc;
using MarketDataAPI.Services;
using MarketDataAPI.Data;

namespace MarketDataAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarketAssetsController : BaseApiController
{
    private readonly IMarketAssetService _marketAssetService;

    public MarketAssetsController(IMarketAssetService marketAssetService)
    {
        _marketAssetService = marketAssetService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarketAsset>>> GetMarketAssets()
    {
        var result = await _marketAssetService.GetMarketAssetsAsync();
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MarketAsset>> GetMarketAsset(int id)
    {
        var result = await _marketAssetService.GetMarketAssetAsync(id);
        return HandleResult(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<MarketAsset>>> GetMarketAssetsPaged(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _marketAssetService.GetMarketAssetsPagedAsync(pageNumber, pageSize);
        return HandlePagedResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<MarketAsset>> PostMarketAsset(MarketAsset marketAsset)
    {
        var result = await _marketAssetService.CreateMarketAssetAsync(marketAsset);
        return HandleResult(result);
    }
}
