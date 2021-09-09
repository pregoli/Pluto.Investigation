using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;

namespace Pluto.Investigation.Domain.Interfaces
{
    public interface IPlanet
    {
        int XLength { get; }
        int YLength { get; }
        HashSet<Coordinate> Obstacles { get; }
        bool ContainsObstaclesAtCoordinate(Coordinate coordinate);
    }
}
