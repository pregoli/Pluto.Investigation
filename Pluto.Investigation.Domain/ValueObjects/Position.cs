using Pluto.Investigation.Domain.Common.Enum;

namespace Pluto.Investigation.Domain.ValueObjects
{
    public class Position
    {
        public Position(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public Coordinate Coordinate { get; private set; }
        public Direction Direction { get; private set; }

        public void Turn(Movement movement)
        {
            switch (Direction)
            {
                case Direction.N:
                    switch (movement)
                    {
                        case Movement.L:
                            Direction = Direction.W;
                            break;
                        case Movement.R:
                            Direction = Direction.E;
                            break;
                    }
                    break;
                case Direction.E:
                    switch (movement)
                    {
                        case Movement.L:
                            Direction = Direction.N;
                            break;
                        case Movement.R:
                            Direction = Direction.S;
                            break;
                    }
                    break;
                case Direction.S:
                    switch (movement)
                    {
                        case Movement.L:
                            Direction = Direction.E;
                            break;
                        case Movement.R:
                            Direction = Direction.W;
                            break;
                    }
                    break;
                case Direction.W:
                    switch (movement)
                    {
                        case Movement.L:
                            Direction = Direction.S;
                            break;
                        case Movement.R:
                            Direction = Direction.N;
                            break;
                    }
                    break;
            }
        }

        public void SetupCoordinate(Coordinate coordinate) => Coordinate = coordinate;
    }
}
