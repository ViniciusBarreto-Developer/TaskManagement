using FluentValidation;
using FluentValidation.Results;

namespace TaskManagement.Core.Commands.TarefaCommands
{
    public class DeleteTarefaCommand : Command<NullResult>
    {
        public string Id { get; set; }

        public override Task<ValidationResult> Validate()
        {
            return Validate(new DeleteTarefaCommandValidation(), this);
        }
    }

    public class DeleteTarefaCommandValidation : AbstractValidator<DeleteTarefaCommand>
    {
        public DeleteTarefaCommandValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("O campo 'Id' é obrigatório.");
        }
    }
}