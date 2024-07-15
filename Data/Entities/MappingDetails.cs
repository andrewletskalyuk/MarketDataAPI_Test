using System.ComponentModel.DataAnnotations;

namespace MarketDataAPI.Data.Entities;

public class MappingDetails
{
    [Key]
    public int Id { get; set; }
    public string Symbol { get; set; } = "";
    public string Exchange { get; set; } = "";
    public int DefaultOrderSize { get; set; }
}
