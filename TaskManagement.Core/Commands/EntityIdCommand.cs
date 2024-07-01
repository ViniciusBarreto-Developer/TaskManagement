using FluentValidation;
using FluentValidation.Results;

namespace TaskManagement.Core.Commands
{
    public class EntityIdCommand : Command<NullResult>
    {
        public int Id { get; set; }

        public override Task<ValidationResult> Validate()
        {
            return Validate(new EntityIdCommandValidation(), this);
        }

        internal class EntityIdCommandValidation : AbstractValidator<EntityIdCommand>
        {
            public EntityIdCommandValidation()
            {
                RuleFor(c => c.Id)
                   .GreaterThan(0);
            }
        }
    }
}
