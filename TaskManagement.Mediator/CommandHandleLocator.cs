using MediatR;

namespace TaskManagement.Mediator
{
    public static class CommandHandlerLocator
    {
        public static ICommandHandlerAdapter Get<TComand>(IMediator mediator) where TComand : ICommand
        {
            return new CommandHandlerAdapter<TComand>(mediator);
        }
    }
}