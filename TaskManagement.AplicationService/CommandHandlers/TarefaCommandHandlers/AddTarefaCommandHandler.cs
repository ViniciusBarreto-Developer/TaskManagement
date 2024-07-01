using TaskManagement.Core.Commands;
using TaskManagement.Core.Commands.TarefaCommands;
using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Models;
using TaskManagement.Mediator;

namespace TaskManagement.AplicationService.CommandHandlers.TarefaCommandHandlers
{
    public class AddTarefaCommandHandler : BaseCommandHandler,
                                           ICommandHandler<AddTarefaCommand, Result<NullResult>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public AddTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result<NullResult>> Handle(AddTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!await ValidateRequest(request))
                return CommandResponse<NullResult>();

            Tarefa tarefa = new()
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                DataDeCriacao = DateTime.Now,
                Status = Status.Pendente
            };

            await _tarefaRepository.CreateAsync(tarefa);

            return CommandResponse<NullResult>();
        }
    }
}
