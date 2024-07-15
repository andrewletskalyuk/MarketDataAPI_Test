using MarketDataAPI.Dtos;
using MarketDataAPI.Models.AssetsModels;

namespace MarketDataAPI.Services;

public interface IHistoricalPriceService
{
    Task<List<HistoricalPriceResponse>> GetHistoricalPricesAsync(HistoricalPriceDto historicalPriceDto);

    Task<List<InstrumentDto>> GetInstrumentsAsync();
}
