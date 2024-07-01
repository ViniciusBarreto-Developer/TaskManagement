using TaskManagement.AplicationService.Services.NotificationService;

namespace TaskManagement.AplicationService.Services
{
    public abstract class BaseService
    {
        #region PROPERTIES AND CONSTRUCTORS

        private readonly INotificationService _notifier;

        protected BaseService(INotificationService notifier)
        {
            _notifier = notifier;
        }

        #endregion

        #region METHODS

        protected bool IsValid()
        {
            return !_notifier.HaveNotification();
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected void NotifyInvalidField(string field)
        {
            Notify($"O campo {field} deve ser fornecido!");
        }

        protected void NotifyInexistenceData(string propertyName)
        {
            Notify($"{propertyName} está em branco ou não existe na base de dados!");
        }

        protected void NotifyFieldInWhite(string nomePropriedade)
        {
            Notify($"{nomePropriedade} não foi fornecido");
        }

        protected void ValidEmissionFactor(decimal? emissionFactor)
        {
            if (emissionFactor == null)
                Notify("Não foi encontrado fator de emissão. Favor entrar em contato com o administrador!");
        }

        #endregion
    }
}
