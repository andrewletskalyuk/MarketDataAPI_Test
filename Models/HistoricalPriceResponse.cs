namespace MarketDataAPI.Models
{
    public class HistoricalPriceResponse
    {
        public string InstrumentId { get; set; } = "";
        public string Provider { get; set; } = "";
        public string Interval { get; set; } = "";
        public string Periodicity { get; set; } = "";
        public List<PriceData> Prices { get; set; } = new List<PriceData>();
    }
}
