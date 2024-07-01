using TaskManagement.Core.Commands;
using TaskManagement.Core.Commands.TarefaCommands;
using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Mediator;

namespace TaskManagement.AplicationService.CommandHandlers.TarefaCommandHandlers
{
    public class DeleteTarefaCommandHandler : BaseCommandHandler,
                                              ICommandHandler<DeleteTarefaCommand, Result<NullResult>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public DeleteTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result<NullResult>> Handle(DeleteTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await ValidateRequest(request))
                return CommandResponse<NullResult>();

            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            if (tarefa == null)
                return CommandNotFoundError<NullResult>(request.Id.ToString(), "Tarefa");

            await _tarefaRepository.DeleteAsync(tarefa.Id);

            return CommandResponse<NullResult>();
        }
    }
}
