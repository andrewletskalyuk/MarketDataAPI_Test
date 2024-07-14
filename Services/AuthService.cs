using System.Text.Json;
using System.Text;

namespace MarketDataAPI.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
    }

    public async Task<string> GetTokenAsync()
    {
        var uri = $"{_configuration["Fintacharts:URI"]}/identity/realms/fintatech/protocol/openid-connect/token";
        var username = _configuration["Fintacharts:USERNAME"];
        var password = _configuration["Fintacharts:PASSWORD"];

        var content = new StringContent(
            $"grant_type=password&client_id=app-cli&username={username}&password={password}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");

        var response = await _httpClient.PostAsync(uri, content);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<JsonElement>(json);
            return data.GetProperty("access_token").GetString();
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Error getting token: {response.StatusCode}, {errorContent}");
        }
    }
}
