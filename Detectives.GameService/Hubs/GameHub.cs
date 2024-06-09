using Microsoft.AspNetCore.SignalR;

namespace Detectives.GameService.Hubs;
public class GameHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}

