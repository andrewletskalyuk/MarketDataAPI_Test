using MarketDataAPI.Data.Entities;

namespace MarketDataAPI.Dtos;

public class MappingsDto
{
    public MappingDetailsDto? ActiveTick { get; set; }
    public MappingDetailsDto? Simulation { get; set; }
    public MappingDetailsDto? Oanda { get; set; }
}
