using Pluto.Investigation.Application.Responses;
using Pluto.Investigation.Domain.Common.Enum;
using Pluto.Investigation.Domain.Interfaces;

namespace Pluto.Investigation.Application.Services
{
    public interface IDeviceControllerService
    {
        ExecuteMovementResponse MoveDevice(Movement[] movements);
    }

    public class DeviceControllerService : IDeviceControllerService
    {
        private readonly IDevice _device;

        public DeviceControllerService(IDevice device)
        {
            _device = device;
        }

        public ExecuteMovementResponse MoveDevice(Movement[] movements)
        {
            _device.Move(movements);
            return new ExecuteMovementResponse(_device);
        }
    }
}
