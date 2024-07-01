namespace TaskManagement.AplicationService.Services.NotificationService
{
    public interface INotificationService
    {
        bool HaveNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notificacao);

        void Notify(string texto);
    }
}
