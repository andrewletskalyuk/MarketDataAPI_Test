using Microsoft.EntityFrameworkCore;

namespace MarketDataAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<MarketAsset> MarketAssets { get; set; }
}
