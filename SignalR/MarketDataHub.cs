using Microsoft.AspNetCore.SignalR;

namespace MarketDataAPI.SignalR;

public class MarketDataHub : Hub
{
    public async Task SendMarketData(string message)
    {
        await Clients.All.SendAsync("ReceiveMarketData", message);
    }
}
