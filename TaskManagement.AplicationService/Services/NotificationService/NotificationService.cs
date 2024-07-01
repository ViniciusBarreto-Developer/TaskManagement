namespace TaskManagement.AplicationService.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly List<Notification> _notifications;

        public NotificationService()
        {
            _notifications = new List<Notification>();
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public void Notify(string message)
        {
            Handle(new Notification(message));
        }
    }
}
