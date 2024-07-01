using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace TaskManagement.Core.Commands
{
    public abstract class Command<TCommandOutput> : IRequest<Result<TCommandOutput>>
    {
        [JsonIgnore]
        public DateTime Timestamp { get; private set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract Task<ValidationResult> Validate();

        public async Task<bool> IsValid()
        {
            if (ValidationResult == null)
            {
                ValidationResult = await Validate();
            }

            return ValidationResult.IsValid;
        }

        protected async Task<ValidationResult> Validate<TValidator, TInput>(TValidator validator, TInput input) where TValidator : AbstractValidator<TInput>
                                                                                        where TInput : Command<TCommandOutput>
        {
            ValidationResult = await validator.ValidateAsync(input);
            return ValidationResult;
        }
    }
}
