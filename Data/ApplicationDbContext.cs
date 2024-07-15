using MarketDataAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketDataAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Instrumenty> Instruments { get; set; }
    public DbSet<Mappings> Mappings { get; set; }
    public DbSet<MappingDetails> MappingDetails { get; set; }
}
