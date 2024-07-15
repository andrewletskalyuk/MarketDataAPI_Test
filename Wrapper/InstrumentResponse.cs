using MarketDataAPI.Data.Entities;

namespace MarketDataAPI.Wrapper;

public class InstrumentResponse
{
    public PagingInfo? Paging { get; set; }
    public List<Instrumenty>? Data { get; set; }
}
