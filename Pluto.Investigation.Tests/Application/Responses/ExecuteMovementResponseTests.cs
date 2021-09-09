using FluentAssertions;
using Pluto.Investigation.Application.Responses;
using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.Entities;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;
using Xunit;

namespace Pluto.Investigation.Tests.Application.Responses
{
    public class ExecuteMovementResponseTests
    {
        [Fact]
        public void Given_No_Collisions_Should_Return_A_Valid_Response()
        {
            //Arrange
            var planet = new Investigation.Domain.Entities.Pluto(10, 10, new HashSet<Coordinate> { new Coordinate(0, 1) });
            var device = new Rover(new Position(new Coordinate(0, 0), Direction.N), planet);
            device.Move(new Movement[] { Movement.F });

            //Act
            var response = new ExecuteMovementResponse(device);

            //Assert
            response.CollisionsCount.Should().Be(1);
            response.Successful.Should().BeFalse();
        }
        
        [Fact]
        public void Given_Collisions_Should_Return_An_Invalid_Response()
        {
            //Arrange
            var planet = new Investigation.Domain.Entities.Pluto(10, 10, null);
            var device = new Rover(new Position(new Coordinate(0, 0), Direction.N), planet);
            device.Move(new Movement[] { Movement.F });

            //Act
            var response = new ExecuteMovementResponse(device);

            //Assert
            response.CollisionsCount.Should().Be(0);
            response.Successful.Should().BeTrue();
        }
    }
}
