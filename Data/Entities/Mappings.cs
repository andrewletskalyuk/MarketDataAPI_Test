using System.ComponentModel.DataAnnotations;

namespace MarketDataAPI.Data.Entities;

public class Mappings
{
    [Key]
    public int Id { get; set; }
    public int InstrumentyId { get; set; }
    public MappingDetails? ActiveTick { get; set; }
    public MappingDetails? Simulation { get; set; }
    public MappingDetails? Oanda { get; set; }
}
