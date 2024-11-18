using Microsoft.AspNetCore.SignalR;

namespace ProjetArtiste1.Data.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
