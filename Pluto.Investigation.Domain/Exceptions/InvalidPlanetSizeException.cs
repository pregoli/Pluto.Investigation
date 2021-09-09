using System;

namespace Pluto.Investigation.Domain.Exceptions
{
    public class InvalidPlanetSizeException : Exception
    {
        public InvalidPlanetSizeException() { }

        public InvalidPlanetSizeException(string axisName)
            : base($"Invalid planet size value detected, {axisName}.") { }

        public InvalidPlanetSizeException(string message, Exception inner)
            : base(message, inner) { }
    }
}
