namespace MarketDataAPI.Models;

public class PagedResult<T> : Result<IEnumerable<T>>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PagedResult(IEnumerable<T> value, int count, int pageNumber, int pageSize)
    {
        Value = value;
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        IsSuccess = true;
    }
}
