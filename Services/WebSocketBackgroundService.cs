namespace MarketDataAPI.Services;

public class WebSocketBackgroundService : BackgroundService
{
    private readonly WebSocketClientService _webSocketClientService;
    private readonly IConfiguration _configuration;

    public WebSocketBackgroundService(WebSocketClientService webSocketClientService, IConfiguration configuration)
    {
        _webSocketClientService = webSocketClientService;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var uri = _configuration["WebSocket:Uri"];
        if(uri !=null)
        await _webSocketClientService.ConnectAsync(uri);
    }
}
