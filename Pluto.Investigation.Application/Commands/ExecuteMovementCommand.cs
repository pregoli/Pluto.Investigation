using Pluto.Investigation.Domain.Common.Enum;

namespace Pluto.Investigation.Application.Commands
{
    public class ExecuteMovementCommand
    {
        public ExecuteMovementCommand(Movement[] movements)
        {
            Movements = movements;
        }

        public Movement[] Movements { get; private set; }
    }
}
