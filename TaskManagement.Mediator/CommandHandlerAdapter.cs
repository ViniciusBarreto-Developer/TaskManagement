using MediatR;

namespace TaskManagement.Mediator
{
    public class CommandHandlerAdapter<TCommandHandler> : ICommandHandlerAdapter
    {
        private readonly IMediator _mediator;

        public CommandHandlerAdapter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Execute<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request);
        }
    }
}