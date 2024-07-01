using FluentValidation;
using FluentValidation.Results;
using TaskManagement.Core.Enums;

namespace TaskManagement.Core.Commands.TarefaCommands
{
    public class UpdateTarefaCommand : Command<NullResult>
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

        public override Task<ValidationResult> Validate()
        {
            return Validate(new UpdateTarefaCommandValidation(), this);
        }
    }

    public class UpdateTarefaCommandValidation : AbstractValidator<UpdateTarefaCommand>
    {
        public UpdateTarefaCommandValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("O campo 'Id' é obrigatório.");

            RuleFor(p => p.Titulo)
                .NotEmpty()
                .WithMessage("O campo 'Titulo' é obrigatório.");

            RuleFor(p => p.Descricao)
                .MaximumLength(300)
                .WithMessage("O campo 'Description' não pode ultrapassar 300 caracteres.");
        }
    }
}
