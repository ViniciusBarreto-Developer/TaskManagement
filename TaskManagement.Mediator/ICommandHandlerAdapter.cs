using MediatR;

namespace TaskManagement.Mediator
{
    public interface ICommandHandlerAdapter
    {
        Task<TResponse> Execute<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}