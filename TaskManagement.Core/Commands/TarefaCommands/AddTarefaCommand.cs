using FluentValidation;
using FluentValidation.Results;

namespace TaskManagement.Core.Commands.TarefaCommands
{
    public class AddTarefaCommand : Command<NullResult>
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public override Task<ValidationResult> Validate()
        {
            return Validate(new AddTarefaCommandValidation(), this);
        }
    }

    public class AddTarefaCommandValidation : AbstractValidator<AddTarefaCommand>
    {
        public AddTarefaCommandValidation()
        {
            RuleFor(p => p.Titulo)
                .NotEmpty()
                .WithMessage("O campo 'Titulo' é obrigatório.");

            RuleFor(p => p.Descricao)
                .MaximumLength(300)
                .WithMessage("O campo 'Description' não pode ultrapassar 300 caracteres.");
        }
    }
}
