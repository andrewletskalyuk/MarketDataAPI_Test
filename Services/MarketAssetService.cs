using MarketDataAPI.Data;
using MarketDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketDataAPI.Services;

public class MarketAssetService : IMarketAssetService
{
    readonly ApplicationDbContext _context;

    public MarketAssetService(ApplicationDbContext context)
    {
        _context = context;
    }

    //public async Task<Result<IEnumerable<MarketAsset>>> GetMarketAssetsAsync()
    //{
    //    var assets = await _context.MarketAssets.ToListAsync();
    //    return Result<IEnumerable<MarketAsset>>.Success(assets);
    //}

    //public async Task<PagedResult<MarketAsset>> GetMarketAssetsPagedAsync(int pageNumber, int pageSize)
    //{
    //    var query = _context.MarketAssets.AsQueryable();
    //    var count = await query.CountAsync();
    //    var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    //    return new PagedResult<MarketAsset>(items, count, pageNumber, pageSize);
    //}

    //public async Task<Result<MarketAsset>> GetMarketAssetAsync(int id)
    //{
    //    var asset = await _context.MarketAssets.FindAsync(id);
    //    return asset != null ? Result<MarketAsset>.Success(asset) : Result<MarketAsset>.Failure("Asset not found");
    //}

    //public async Task<Result<MarketAsset>> CreateMarketAssetAsync(MarketAsset marketAsset)
    //{
    //    _context.MarketAssets.Add(marketAsset);
    //    await _context.SaveChangesAsync();
    //    return Result<MarketAsset>.Success(marketAsset);
    //}
}
