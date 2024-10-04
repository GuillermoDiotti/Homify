using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Devices.Models;
using Homify.WebApi.Controllers.Homes.Models;
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
        if (req == null)
        {
            throw new NullRequestException();
        }

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, req.IsExterior, req.IsInterior);
        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);
        if (companyOwner == null)
        {
            throw new NotFoundException("Owner not found");
        }

        if (companyOwner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be complete");
        }

        Camera cam = _deviceService.AddCamera(args, companyOwner);

        return new CreateDeviceResponse(cam);
    }

    [HttpPost("sensors")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.RegisterSensor)]
    public CreateDeviceResponse RegisterSensor(CreateSensorRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException();
        }

        var isExterior = false;
        var user = GetUserLogged();

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, isExterior, isExterior);
        var companyOwner = _companyOwnerService.GetById(user.Id);
        if (companyOwner == null)
        {
            throw new NotFoundException("Owner not found");
        }

        if (companyOwner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be complete");
        }

        Sensor sen = _deviceService.AddSensor(args, companyOwner);

        return new CreateDeviceResponse(sen);
    }

    [HttpGet("supported")]
    [AuthenticationFilter]
    public List<SearchDevicesResponse> ObtainDevices([FromQuery] string? deviceName, [FromQuery] string? model, [FromQuery] string? company,
        [FromQuery] string? type, [FromQuery] string? limit, [FromQuery] string? offset)
    {
        var searchArgs = new SearchDevicesArgs
        {
            DeviceName = deviceName,
            Model = model,
            Company = company,
            Type = type,
            Limit = string.IsNullOrEmpty(limit) ? 10 : int.Parse(limit),
            Offset = string.IsNullOrEmpty(offset) ? 0 : int.Parse(offset)
        };

        var devices = _deviceService.SearchDevices(searchArgs);

        var response = devices.Select(d => new SearchDevicesResponse(d)).ToList();

        return response;
    }
}
