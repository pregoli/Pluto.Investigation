using Microsoft.AspNetCore.Mvc;
using Pluto.Investigation.Application.Commands;
using Pluto.Investigation.Application.Responses;
using Pluto.Investigation.Application.Services;

namespace Pluto.Investigation.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RouterController : Controller
    {
        private readonly IDeviceControllerService _deviceControllerService;

        public RouterController(IDeviceControllerService deviceControllerService)
        {
            _deviceControllerService = deviceControllerService;
        }

        [HttpPost("beta/[controller]/move")]
        public ExecuteMovementResponse Move(ExecuteMovementCommand command)
        {
            return _deviceControllerService.MoveDevice(command.Movements);
        }
    }
}
