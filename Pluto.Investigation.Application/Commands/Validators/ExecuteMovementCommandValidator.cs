using FluentValidation;
using System.Linq;

namespace Pluto.Investigation.Application.Commands.Validators
{
    public class ExecuteMovementCommandValidator : AbstractValidator<ExecuteMovementCommand>
    {
        public ExecuteMovementCommandValidator()
        {
            RuleFor(command => command.Movements)
                .Must(movements => movements != null && movements.Any())
                .WithMessage("At least one movement expected");
        }
    }
}
