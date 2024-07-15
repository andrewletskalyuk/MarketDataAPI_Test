namespace MarketDataAPI.Dtos;

public class HistoricalPriceDto
{
    public List<string> InstrumentIds { get; set; } = new List<string>();

    public DateTime startDate { get; set; } = DateTime.UtcNow.AddDays(-1);
}
