using FluentAssertions;
using Pluto.Investigation.Domain.Exceptions;
using Pluto.Investigation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Pluto.Investigation.Tests.Domain.Entities
{
    public class PlutoTests
    {
        [Fact]
        public void Given_A_Null_Or_Negative_Coordinate_xLength_Value_Should_Throw_An_InvalidPlanetSizeException()
        {
            //Act
            Action act = () => new Investigation.Domain.Entities.Pluto(-1, 0, null);

            //Assert
            act.Should().Throw<InvalidPlanetSizeException>()
                .WithMessage($"Invalid planet size value detected, xLength.");
        }

        public class ContainsObstaclesAtCoordinate
        {
            [Fact]
            public void Should_Contain_Obstacles()
            {
                //Arrange
                var coordinate = new Coordinate(1, 1);
                var obstacles= new HashSet<Coordinate> { coordinate };

                //Act
                var pluto = new Investigation.Domain.Entities.Pluto(10, 10, obstacles);

                //Arrange
                pluto.ContainsObstaclesAtCoordinate(coordinate);
            }

            [Theory]
            [InlineData(1,2)]
            [InlineData(3,3)]
            [InlineData(1,5)]
            public void Should_Not_Contain_Obstacles(int givenCoordinateX, int givenCoordinateY)
            {
                //Arrange
                var coordinate = new Coordinate(givenCoordinateX, givenCoordinateY);
                var obstacles = new HashSet<Coordinate> { new Coordinate(2, 2) };

                //Act
                var pluto = new Investigation.Domain.Entities.Pluto(10, 10, obstacles);

                //Arrange
                pluto.ContainsObstaclesAtCoordinate(coordinate);
            }
        }
    }
}
