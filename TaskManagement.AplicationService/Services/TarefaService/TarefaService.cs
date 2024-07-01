using TaskManagement.AplicationService.Services.NotificationService;

namespace TaskManagement.AplicationService.Services.TarefaService
{
    public class TarefaService : BaseService, ITarefaService
    {
        public TarefaService(INotificationService notifier) : base(notifier)
        {
        }


    }
}
