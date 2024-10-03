using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Devices.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Devices;

[ApiController]
[Route("devices")]
public class DeviceController : HomifyControllerBase
{
    private readonly IDeviceService _deviceService;
    private readonly ICompanyOwnerService _companyOwnerService;

    public DeviceController(IDeviceService deviceService, ICompanyOwnerService companyOwnerService)
    {
        _deviceService = deviceService;
        _companyOwnerService = companyOwnerService;
    }

    [HttpPost("cameras")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.RegisterCamera)]
    public CreateDeviceResponse RegisterCamera(CreateCameraRequest req)
    {
        // TODO: verificar que solo puedan acceder los de cuentas COMPLETAS
        if (req == null)
        {
            throw new NullRequestException();
        }

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, req.IsExterior, req.IsInterior);
        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);
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
        var user = GetUserLogged();

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, isExterior, isExterior);
        var companyOwner = _companyOwnerService.GetById(user.Id);

        Sensor sen = _deviceService.AddSensor(args, companyOwner);

        return new CreateDeviceResponse(sen);
    }
}
