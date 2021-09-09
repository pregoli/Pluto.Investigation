using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.Interfaces;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;

namespace Pluto.Investigation.Domain.Entities
{
    public class Rover : IDevice
    {
        private readonly IPlanet _planet;
        public Rover(Position position, IPlanet planet)
        {
            Position = position;
            _planet = planet;
        }

        public Position Position { get; private set; }
        public HashSet<Coordinate> DetectedCollisions { get; private set; } = new HashSet<Coordinate>();

        public void Move(Movement[] movements)
        {
            foreach (var movement in movements)
            {
                switch (movement)
                {
                    case Movement.F:
                        MoveForward();
                        break;
                    case Movement.B:
                        MoveBackward();
                        break;
                    case Movement.L:
                    case Movement.R:
                        Position.Turn(movement);
                        break;
                }
            }
        }

        private void MoveForward()
        {
            var currentXAxis = Position.Coordinate.XAxis;
            var currentYAxis = Position.Coordinate.YAxis;
            var currentDirection = Position.Direction;

            switch (Position.Direction)
            {
                case Direction.N:
                    currentYAxis = StepForwardOnYAxis(currentYAxis);
                    break;
                case Direction.E:
                    currentXAxis = StepForwardOnXAxis(currentXAxis);
                    break;
                case Direction.S:
                    currentYAxis = StepBackOnYAxes(currentYAxis);
                    break;
                case Direction.W:
                    currentXAxis = StepBackOnXAxis(currentXAxis);
                    break;
            }

            var eventualNewCoordinate = new Coordinate(currentXAxis, currentYAxis);
            if (CurrentPositionContainsObstacles(eventualNewCoordinate))
                return;

            Position = new Position(eventualNewCoordinate, currentDirection);
        }

        private void MoveBackward()
        {
            var currentXAxis = Position.Coordinate.XAxis;
            var currentYAxis = Position.Coordinate.YAxis;
            var currentDirection = Position.Direction;

            switch (Position.Direction)
            {
                case Direction.N:
                    currentYAxis = StepBackOnYAxes(currentYAxis);
                    break;
                case Direction.E:
                    currentXAxis = StepBackOnXAxis(currentXAxis);
                    break;
                case Direction.S:
                    currentYAxis = StepForwardOnYAxis(currentYAxis);
                    break;
                case Direction.W:
                    currentXAxis = StepForwardOnXAxis(currentXAxis);
                    break;
            }

            var eventualNewCoordinate = new Coordinate(currentXAxis, currentYAxis);
            if (CurrentPositionContainsObstacles(eventualNewCoordinate))
                return;

            Position = new Position(eventualNewCoordinate, currentDirection);
        }

        private int StepForwardOnXAxis(int currentXAxis) => currentXAxis + 1 == _planet.XLength ? 0 : currentXAxis + 1;

        private int StepForwardOnYAxis(int currentYAxis) => currentYAxis + 1 == _planet.YLength ? 0 : currentYAxis + 1;

        private int StepBackOnXAxis(int currentXAxis) => currentXAxis - 1 < 0 ? _planet.XLength : currentXAxis - 1;

        private int StepBackOnYAxes(int currentYAxis) => currentYAxis - 1 < 0 ? _planet.YLength : currentYAxis - 1;

        private bool CurrentPositionContainsObstacles(Coordinate eventualNewCoordinate)
        {
            if (_planet.Obstacles.Contains(eventualNewCoordinate))
            {
                DetectedCollisions.Add(eventualNewCoordinate);
                return true;
            }

            return false;
        }
    }
}
