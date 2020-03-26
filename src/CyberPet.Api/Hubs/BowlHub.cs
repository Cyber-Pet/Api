using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CyberPet.Api.Hubs
{
    public class BowlHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
