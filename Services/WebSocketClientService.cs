using MarketDataAPI.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;
using System.Text;

namespace MarketDataAPI.Services;

public class WebSocketClientService
{
    private readonly IHubContext<MarketDataHub> _hubContext;
    private readonly IAuthService _authService;
    private ClientWebSocket _webSocket;

    public WebSocketClientService(IHubContext<MarketDataHub> hubContext, IAuthService authService)
    {
        _hubContext = hubContext;
        _authService = authService;
        _webSocket = new ClientWebSocket();
    }

    public async Task ConnectAsync(string uri)
    {
        var token = await _authService.GetTokenAsync();
        _webSocket.Options.SetRequestHeader("Authorization", $"Bearer {token}");
        await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
        await ReceiveAsync();
    }

    private async Task ReceiveAsync()
    {
        var buffer = new byte[1024 * 4];
        while (_webSocket.State == WebSocketState.Open)
        {
          var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                await _hubContext.Clients.All.SendAsync("ReceiveMarketData", message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
        }
    }
}
