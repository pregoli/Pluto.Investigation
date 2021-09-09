using FluentValidation.TestHelper;
using Pluto.Investigation.Application.Commands;
using Pluto.Investigation.Application.Commands.Validators;
using Pluto.Investigation.Domain.Common.Enum;
using Xunit;

namespace Pluto.Investigation.Tests.Application.Commands.Validators
{
    public class ExecuteMovementCommandValidatorTests
    {
        [Fact]
        public void Given_No_Movements_The_Command_Should_Be_Invalid()
        {
            //Arrange
            var validator = new ExecuteMovementCommandValidator();
            var command = new ExecuteMovementCommand(null);

            //Act
            var result = validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(command => command.Movements);
        }
        
        [Fact]
        public void Given_One_Or_More_Movements_The_Command_Should_Be_Valid()
        {
            //Arrange
            var validator = new ExecuteMovementCommandValidator();
            var command = new ExecuteMovementCommand(new Movement[] { Movement.B });

            //Act
            var result = validator.TestValidate(command);

            //Assert
            result.ShouldNotHaveValidationErrorFor(command => command.Movements);
        }
    }
}
