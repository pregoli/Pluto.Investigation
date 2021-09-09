using FluentAssertions;
using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.ValueObjects;
using Xunit;

namespace Pluto.Investigation.Tests.Domain.ValueObjects
{
    public class PositionTests
    {
        public class Turn
        {
            [Theory]
            [InlineData(Direction.N, Movement.R, 1, 2, Direction.E)]
            [InlineData(Direction.N, Movement.L, 10, 20, Direction.W)]
            [InlineData(Direction.S, Movement.L, 30, 40, Direction.E)]
            [InlineData(Direction.S, Movement.R, 50, 60, Direction.W)]
            public void Given_A_Current_Direction_When_A_Left_Or_Right_Movement_Has_Submitted_The_Direction_Should_Change_But_Not_The_Coordinate(
                Direction currentDirection,
                Movement movement,
                int startingCoordinateX,
                int startingCoordinateY,
                Direction expectedDirection)
            {
                //Arrange
                var startingCoordinate = new Coordinate(startingCoordinateX, startingCoordinateY);
                var position = new Position(startingCoordinate, currentDirection);

                //Act
                position.Turn(movement);

                //Assert
                position.Direction.Should().Be(expectedDirection);
                position.Coordinate.Should().Be(startingCoordinate);
            }
            
            [Theory]
            [InlineData(Direction.N, Movement.F, Direction.E)]
            [InlineData(Direction.N, Movement.B, Direction.W)]
            [InlineData(Direction.S, Movement.B, Direction.E)]
            [InlineData(Direction.S, Movement.F, Direction.W)]
            public void Given_A_Current_Direction_When_A_Forward_Or_Back_Movement_Has_Submitted_The_Direction_Should_Not_Change(
                Direction currentDirection,
                Movement movement,
                Direction expectedDirection)
            {
                //Arrange
                var position = new Position(new Coordinate(1, 2), currentDirection);

                //Act
                position.Turn(movement);

                //Assert
                position.Direction.Should().NotBe(expectedDirection);
                position.Direction.Should().Be(currentDirection);
            }
        }

        public class SetupCoordinate
        {
            [Theory]
            [InlineData(1, 2)]
            [InlineData(3, 3)]
            [InlineData(1, 5)]
            public void Should_Setup_New_Coordinate(int newCoordinateX, int newCoordinateY)
            {
                //Arrange
                var position = new Position(new Coordinate(1, 1), Direction.E);
                var newCoordinate = new Coordinate(newCoordinateX, newCoordinateY);

                //Act
                position.SetupCoordinate(newCoordinate);

                //Arrange
                position.Coordinate.Should().Be(newCoordinate);
            }
        }
    }
}
