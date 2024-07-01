using FluentValidation.Results;
using System.Linq.Expressions;
using System.Reflection;
using TaskManagement.Core.Commands;
using TaskManagement.Core.Contracts;
using TaskManagement.Mediator;

namespace TaskManagement.AplicationService.CommandHandlers
{
    public abstract class BaseCommandHandler : IHaveValidationResult, ICommand
    {
        public ValidationResult ValidationResult { get; set; }

        public BaseCommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected async Task<bool> ValidateRequest<TCommand>(Command<TCommand> request)
        {
            ValidationResult = await request.Validate();
            return await request.IsValid();
        }

        protected Result<TCommandOutput> CommandResponse<TCommandOutput>(TCommandOutput commandOutput) where TCommandOutput : class
        {
            return new Result<TCommandOutput>(commandOutput)
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandResponse<TCommandOutput>()
        {
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandError<TCommandOutput>(string errorMsg)
        {
            AddError(errorMsg);
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandDependencieError<TCommandOutput>()
        {
            AddError("Não é possivel deletar, pois está sendo utilizado em outros processos!");
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandNotFoundError<TCommandOutput>(string id, string? entidade = "Principal")
        {
            AddError("Entidade " + entidade + " não encontrada para o id: " + id);
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandNotFoundError<TCommandOutput>(int id, string? entidade = "Principal")
        {
            AddError("Entidade " + entidade + " não encontrada para o id: " + id);
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        protected Result<TCommandOutput> CommandExistError<TCommandOutput>(string entidade)
        {
            AddError(entidade + " já cadastrado(a)!");
            return new Result<TCommandOutput>()
            {
                ValidationResult = ValidationResult
            };
        }

        public bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public void AddError<T>(Expression<Func<T>> property, string message)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Propriedade inválida {property}", "property");
            }
            ValidationResult.Errors.Add(new ValidationFailure(propertyInfo.Name, message));
        }


        public void AddErrors(ICollection<string> messages)
        {
            foreach (var message in messages)
            {
                AddError(message);
            }
        }
    }
}
