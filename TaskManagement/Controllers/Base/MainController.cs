using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.AplicationService.Services.NotificationService;
using TaskManagement.Core.Commands;
using TaskManagement.Mediator;

namespace TaskManagement.Controllers.Base
{
    public class MainController : ControllerBase
    {
        private readonly INotificationService _notifier;

        public MainController(INotificationService notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HaveNotification();
        }

        protected ActionResult<TResponseType> CustomCommandResponse<TResponseType>(Result<TResponseType> commandOutput)
        {
            if (commandOutput.IsValid())
                return CustomOkResponse(commandOutput.Data);

            return CustomBadRequestResponse(commandOutput.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (ValidOperation())
                return CustomOkResponse(result);

            return CustomBadRequestResponse(_notifier.GetNotifications()
                                                     .Select(n => n.Message)
                                                     .ToList());
        }

        protected ICommandHandlerAdapter Command<TCommandHandler>() where TCommandHandler : ICommand
        {
            IMediator? mediator = HttpContext.RequestServices.GetService<IMediator>();

            return mediator == null ? throw new Exception("IMediator not found.") : CommandHandlerLocator.Get<TCommandHandler>(mediator);
        }

        protected ActionResult CustomOkResponse(object? result = null)
        {
            return Ok(new
            {
                Dados = result
            });
        }

        protected ActionResult CustomBadRequestResponse(List<string> errorList)
        {
            return BadRequest(new
            {
                Erros = errorList
            });
        }

        protected void NotifyError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
