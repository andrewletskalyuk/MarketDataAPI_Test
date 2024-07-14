using MarketDataAPI.Models;
using MarketDataAPI.Models.InstrumentsClasses;

namespace MarketDataAPI.Services;

public interface IHistoricalPriceService
{
    Task<List<PriceData>> GetHistoricalPricesAsync(string instrumentId, 
        DateTime startDate, DateTime endDate);

    Task<List<Instrumenty>> GetInstrumentsAsync();
}
