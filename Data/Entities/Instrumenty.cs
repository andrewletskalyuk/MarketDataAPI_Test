using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDataAPI.Data.Entities;

public class Instrumenty
{
    [Key]
    public string Id { get; set; } = "";
    public string Symbol { get; set; } = "";
    public string Kind { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal TickSize { get; set; }
    public string Currency { get; set; } = "";
    public string BaseCurrency { get; set; } = "";
    public int Price { get; set; }

    [ForeignKey("InstrumentyId")]
    public Mappings? Mappings { get; set; }
}
