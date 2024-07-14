namespace MarketDataAPI.Services;

public interface IAuthService
{
    Task<string> GetTokenAsync();
}
