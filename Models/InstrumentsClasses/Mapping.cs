namespace MarketDataAPI.Models.InstrumentsClasses;

public class Mapping
{
    public Guid MappingId { get; set; }
    public Guid InstrumentId { get; set; }
    public string Provider { get; set; } = "";
    public string Symbol { get; set; } = "";
    public string Exchange { get; set; } = "";
    public int DefaultOrderSize { get; set; }

    public Instrumenty? Instrumenty { get; set; }
}
