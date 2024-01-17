using Microsoft.AspNetCore.SignalR;

namespace Projeto_Bolg.Services
{
	public class NotificationHub : Hub
    {
        public async Task SendNotificationAsync(string message)
        {
            await Clients.All.SendAsync("Notification", message);
        }
    }
}