namespace MarketDataAPI.Dtos;

public class MappingDetailsDto
{
    public string Symbol { get; set; } = "";
    public string Exchange { get; set; } = "";
    public int DefaultOrderSize { get; set; }
}
