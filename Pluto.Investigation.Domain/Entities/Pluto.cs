using Pluto.Investigation.Domain.Exceptions;
using Pluto.Investigation.Domain.Interfaces;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;

namespace Pluto.Investigation.Domain.Entities
{
    public class Pluto : IPlanet
    {
        public int XLength { get; private set; }
        public int YLength { get; private set; }
        public HashSet<Coordinate> Obstacles { get; private set; }

        public Pluto(int xLength, int yLength, HashSet<Coordinate> obstacles)
        {
            XLength = xLength < 0 ? throw new InvalidPlanetSizeException(nameof(xLength)) : xLength;
            YLength = yLength < 0 ? throw new InvalidPlanetSizeException(nameof(yLength)) : yLength;
            Obstacles = obstacles ?? new HashSet<Coordinate>();
        }
    }
}
