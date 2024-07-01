using FluentValidation.Results;
using System.Text.Json.Serialization;
using TaskManagement.Core.Contracts;

namespace TaskManagement.Core.Commands
{
    public interface ICommandOutput
    {
    }

    public class Result<TCommandOutput> : ICommandOutput, IHaveValidationResult
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
        public TCommandOutput Data { get; protected set; }

        public Result(TCommandOutput data)
        {
            if (data is not NullResult)
                Data = data;
        }

        public Result()
        {
        }

        public bool IsValid()
        {
            return ValidationResult?.IsValid ?? false;
        }
    }
}
