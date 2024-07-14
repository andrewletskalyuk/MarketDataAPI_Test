using MarketDataAPI.Data;
using MarketDataAPI.Models;

namespace MarketDataAPI.Services;

public interface IMarketAssetService
{
    Task<Result<IEnumerable<MarketAsset>>> GetMarketAssetsAsync();
    Task<PagedResult<MarketAsset>> GetMarketAssetsPagedAsync(int pageNumber, int pageSize);
    Task<Result<MarketAsset>> GetMarketAssetAsync(int id);
    Task<Result<MarketAsset>> CreateMarketAssetAsync(MarketAsset marketAsset);
}
