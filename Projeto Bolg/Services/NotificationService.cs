using System;
using Microsoft.AspNetCore.SignalR;

namespace Projeto_Bolg.Services
{
	public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(
            ILogger<NotificationService> logger,
            IHubContext<NotificationHub> hubContext)
		{
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(NotificationMessage message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}

