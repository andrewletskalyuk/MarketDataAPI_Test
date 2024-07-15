namespace MarketDataAPI.Models.AssetsModels
{
    public class HistoricalPriceResponse
    {
        public string InstrumentId { get; set; } = "";

        public List<PriceData> Prices { get; set; } = new List<PriceData>();
    }
}
