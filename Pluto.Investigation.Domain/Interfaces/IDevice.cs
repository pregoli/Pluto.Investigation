using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;

namespace Pluto.Investigation.Domain.Interfaces
{
    public interface IDevice
    {
        Position Position { get; }
        HashSet<Coordinate> DetectedCollisions { get; }
        void Move(Movement[] movements);
    }
}
