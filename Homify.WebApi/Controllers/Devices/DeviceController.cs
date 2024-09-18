using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Devices;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Devices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Devices;

[ApiController]
[Route("devices")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpPost("cameras")]
    public CreateDeviceResponse RegisterCamera(CreateCameraRequest req)
    {
        // TODO: verificar que solo puedan acceder los de cuentas COMPLETAS
        if (req == null)
        {
            throw new NullRequestException();
        }

        var args = new CreateCameraArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty);

        Camera cam = _deviceService.AddCamera(args);

        return new CreateDeviceResponse(cam);
    }
}
