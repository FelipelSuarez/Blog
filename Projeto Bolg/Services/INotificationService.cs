namespace Projeto_Bolg.Services
{
	public interface INotificationService
	{
        Task SendNotificationAsync(NotificationMessage message);
    }
}