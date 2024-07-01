using MediatR;

namespace TaskManagement.Mediator
{
    public interface ICommandHandler<TCommand, TCommandOutput> : IRequestHandler<TCommand, TCommandOutput>
        where TCommand : IRequest<TCommandOutput>
    {
    }
}
