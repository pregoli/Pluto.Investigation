using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.Exceptions;

namespace Pluto.Investigation.Domain.ValueObjects
{
    public struct Coordinate
    {
        public Coordinate(int xAxis, int yAxis)
        {
            XAxis = xAxis < 0 ? throw new InvalidCoordinateException(nameof(xAxis)) : xAxis;
            YAxis = yAxis < 0 ? throw new InvalidCoordinateException(nameof(yAxis)) : yAxis;
        }

        public int XAxis { get; private set; }
        public int YAxis { get; private set; }
    }
}
