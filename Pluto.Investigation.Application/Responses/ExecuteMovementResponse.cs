using Pluto.Investigation.Domain.Interfaces;
using Pluto.Investigation.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Pluto.Investigation.Application.Responses
{
    public class ExecuteMovementResponse
    {
        public ExecuteMovementResponse(
            IDevice device)
        {
            Position = device.Position;
            DetectedCollisions = device.DetectedCollisions;
        }

        public Position Position { get; private set; }
        public HashSet<Coordinate> DetectedCollisions { get; private set; } = new HashSet<Coordinate>();
        public int CollisionsCount => DetectedCollisions.Count;
        public bool Successful => DetectedCollisions != null && !DetectedCollisions.Any();
    }
}
