using FluentAssertions;
using Pluto.Investigation.Domain.Exceptions;
using Pluto.Investigation.Domain.ValueObjects;
using System;
using Xunit;

namespace Pluto.Investigation.Tests.Domain.ValueObjects
{
    public class CoordinateTests
    {
        [Fact]
        public void Given_A_Null_Or_Negative_Coordinate_Axis_Value_Should_Throw_An_InvalidCoordinateException()
        {
            //Act
            Action act = () => new Coordinate(-1, 0);

            //Assert
            act.Should().Throw<InvalidCoordinateException>()
                .WithMessage($"Invalid coordinate value detected, xAxis.");
        }
        
        [Theory]
        [InlineData(1,1)]
        [InlineData(0,10)]
        [InlineData(4,18)]
        [InlineData(5,98)]
        [InlineData(7,109)]
        public void Given_Valid_Coordinate_Axis_Value_The_Expected_Values_Should_Be_Set(int xAxis, int yAxis)
        {
            //Act
            var coordinate = new Coordinate(xAxis, yAxis);

            //Assert
            coordinate.XAxis.Should().Be(xAxis);
            coordinate.YAxis.Should().Be(yAxis);
        }
    }
}
