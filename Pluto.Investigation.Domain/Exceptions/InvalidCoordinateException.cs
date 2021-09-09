using System;

namespace Pluto.Investigation.Domain.Exceptions
{
    [Serializable]
    public class InvalidCoordinateException : Exception
    {
        public InvalidCoordinateException() { }

        public InvalidCoordinateException(string axisName)
            : base($"Invalid coordinate value detected, {axisName}.") { }

        public InvalidCoordinateException(string message, Exception inner)
            : base(message, inner) { }
    }
}
