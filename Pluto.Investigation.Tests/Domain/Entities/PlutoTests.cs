using FluentAssertions;
using Pluto.Investigation.Domain.Exceptions;
using System;
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
    }
}
