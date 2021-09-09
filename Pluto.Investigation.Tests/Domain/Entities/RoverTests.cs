using FluentAssertions;
using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.Entities;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;
using Xunit;

namespace Pluto.Investigation.Tests.Domain.Entities
{
    public class RoverTests
    {
        public class Move
        {
            [Theory]
            [InlineData(new Movement[]
                {
                    Movement.F,
                    Movement.F,
                    Movement.R,
                    Movement.F,
                    Movement.F
                }, Direction.N, 100, 100, 0, 0, 2, 2)]
            [InlineData(new Movement[]
                {
                    Movement.B
                }, Direction.N, 100, 100, 0, 0, 0, 100)]
            [InlineData(new Movement[]
                {
                    Movement.B,
                    Movement.R,
                    Movement.F
                }, Direction.N, 100, 100, 0, 0, 1, 100)]
            [InlineData(new Movement[]
                {
                    Movement.B,
                    Movement.R,
                    Movement.F,
                    Movement.L,
                    Movement.L,
                    Movement.F,
                }, Direction.N, 100, 100, 0, 0, 0, 100)]
            [InlineData(new Movement[]
                {
                    Movement.F,
                    Movement.F,
                }, Direction.W, 100, 100, 0, 0, 99, 0)]
            [InlineData(new Movement[]
                {
                    Movement.F,
                    Movement.F,
                    Movement.L,
                    Movement.F,
                    Movement.R,
                    Movement.B,
                }, Direction.E, 100, 100, 0, 0, 1, 1)]
            [InlineData(new Movement[]
                {
                    Movement.F,
                    Movement.F,
                    Movement.R,
                    Movement.F,
                    Movement.F,
                    Movement.R,
                    Movement.F,
                    Movement.F,
                    Movement.L,
                    Movement.F,
                    Movement.B,
                }, Direction.S, 100, 100, 0, 0, 99, 1)]
            public void Given_No_Obstacles_It_Should_To_Reach_The_Desired_Position(
                Movement[] movements,
                Direction startingDirection,
                int planetXLength,
                int planetYLength,
                int roverStartingPositionX,
                int roverStartingPositionY,
                int expectedRoverXposition,
                int expectedRoverYposition)
            {
                //Arrange
                var startingPosition = new Position(new Coordinate(roverStartingPositionX, roverStartingPositionY), startingDirection);
                var planet = new Investigation.Domain.Entities.Pluto(planetXLength, planetYLength, null);
                var rover = new Rover(startingPosition, planet);

                //Act
                rover.Move(movements);

                //Assert
                rover.Position.Coordinate.XAxis.Should().Be(expectedRoverXposition);
                rover.Position.Coordinate.YAxis.Should().Be(expectedRoverYposition);
            }
            
            [Theory]
            [InlineData(new Movement[]
                {
                    Movement.F,
                    Movement.F,
                    Movement.L,
                    Movement.F,
                    Movement.R,
                    Movement.R,
                    Movement.F,
                    Movement.F,
                }, Direction.N, 5, 5, 0, 0, 1, 2)]
            public void Should_Detect_Obstacles_During_Movements(
                Movement[] movements,
                Direction startingDirection,
                int planetXLength,
                int planetYLength,
                int roverStartingPositionX,
                int roverStartingPositionY,
                int expectedRoverXposition,
                int expectedRoverYposition)
            {
                //Arrange
                var collisionsExpected = new HashSet<Coordinate> { new Coordinate(5, 2), new Coordinate(2, 2) };
                var startingPosition = new Position(new Coordinate(roverStartingPositionX, roverStartingPositionY), startingDirection);
                var planet = new Investigation.Domain.Entities.Pluto(
                    planetXLength, 
                    planetYLength,
                    collisionsExpected);

                var rover = new Rover(startingPosition, planet);

                //Act
                rover.Move(movements);

                //Assert
                rover.Position.Coordinate.XAxis.Should().Be(expectedRoverXposition);
                rover.Position.Coordinate.YAxis.Should().Be(expectedRoverYposition);
                rover.DetectedCollisions.Should().BeEquivalentTo(collisionsExpected);
            }
        }
    }
}
