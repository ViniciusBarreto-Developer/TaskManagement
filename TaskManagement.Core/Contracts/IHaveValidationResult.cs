using FluentValidation.Results;

namespace TaskManagement.Core.Contracts
{
    public interface IHaveValidationResult
    {
        ValidationResult ValidationResult { get; set; }

        bool IsValid();

    }
}
