using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Devices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Devices;

[ApiController]
[Route("devices")]
public class DeviceController : HomifyControllerBase
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

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, req.IsExterior, req.IsInterior);
        var companyOwner = GetUserLogged();

        Camera cam = _deviceService.AddCamera(args, companyOwner);

        return new CreateDeviceResponse(cam);
    }

    [HttpPost("sensors")]
    public CreateDeviceResponse RegisterSensor(CreateSensorRequest req)
    {
        // TODO: verificar que solo puedan acceder los de cuentas COMPLETAS
        if (req == null)
        {
            throw new NullRequestException();
        }

        var isExterior = false;
        var companyOwner = GetUserLogged();

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, isExterior, isExterior);

        Sensor sen = _deviceService.AddSensor(args,companyOwner);

        return new CreateDeviceResponse(sen);
    }
}
