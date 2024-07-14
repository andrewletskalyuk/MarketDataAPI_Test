using MarketDataAPI.Models.InstrumentsClasses;

namespace MarketDataAPI.Wrapper;

public class InstrumentResponse
{
    public PagingInfo? Paging { get; set; }
    public List<Instrumenty>? Data { get; set; }
}
