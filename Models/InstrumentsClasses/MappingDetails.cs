namespace MarketDataAPI.Models.InstrumentsClasses;

public class MappingDetails
{
    public string Symbol { get; set; } = "";
    public string Exchange { get; set; } = "";
    public int DefaultOrderSize { get; set; }
}
