using TaskManagement.Core.Commands;
using TaskManagement.Core.Commands.TarefaCommands;
using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Domain.Enums;
using TaskManagement.Mediator;

namespace TaskManagement.AplicationService.CommandHandlers.TarefaCommandHandlers
{
    public class UpdateTarefaCommandHandler : BaseCommandHandler,
                                              ICommandHandler<UpdateTarefaCommand, Result<NullResult>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result<NullResult>> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await ValidateRequest(request))
                return CommandResponse<NullResult>();

            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            if (tarefa == null)
                return CommandNotFoundError<NullResult>(request.Id.ToString(), "Tarefa");

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;
            tarefa.Status = (Status)request.Status;

            if (tarefa.Status == Status.Concluida && tarefa.DataDeConclusao == null)
            {
                tarefa.DataDeConclusao = DateTime.Now;
            }
            else
                tarefa.DataDeConclusao = null;

            await _tarefaRepository.UpdateAsync(tarefa);

            return CommandResponse<NullResult>();
        }
    }
}
