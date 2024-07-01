using Microsoft.AspNetCore.Mvc;
using TaskManagement.AplicationService.CommandHandlers.TarefaCommandHandlers;
using TaskManagement.AplicationService.Services.NotificationService;
using TaskManagement.Controllers.Base;
using TaskManagement.Core.Commands;
using TaskManagement.Core.Commands.TarefaCommands;
using TaskManagement.Domain.Contracts.Repositories;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(INotificationService notifier,
                                ITarefaRepository tarefaRepository) : base(notifier)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<NullResult>> Add([FromBody] AddTarefaCommand input)
        {
            var commandResponse = await Command<AddTarefaCommandHandler>().Execute(input);
            return CustomCommandResponse(commandResponse);
        }

        [HttpPut]
        public async Task<ActionResult<NullResult>> Update([FromBody] UpdateTarefaCommand input)
        {
            var commandResponse = await Command<UpdateTarefaCommandHandler>().Execute(input);
            return CustomCommandResponse(commandResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<NullResult>> Delete([FromBody] DeleteTarefaCommand input)
        {
            var commandResponse = await Command<DeleteTarefaCommandHandler>().Execute(input);
            return CustomCommandResponse(commandResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var viewModel = await _tarefaRepository.GetByIdAsync(id);

            if (viewModel == null)
            {
                var listaErro = new List<string>() { "Tarefa não encontrada!" };
                return CustomBadRequestResponse(listaErro);
            }

            return CustomResponse(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _tarefaRepository.GetAllAsync();

            return CustomResponse(list);
        }
    }
}
