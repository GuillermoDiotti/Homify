using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Devices.Models.Requests;
using Homify.WebApi.Controllers.Devices.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Devices;

[ApiController]
[Route("devices")]
public class DeviceController : HomifyControllerBase
{
    private readonly IDeviceService _deviceService;
    private readonly ICompanyOwnerService _companyOwnerService;
    private readonly IHomeDeviceService _homeDeviceService;

    public DeviceController(IDeviceService deviceService, ICompanyOwnerService companyOwnerService, IHomeDeviceService homeDeviceService)
    {
        _deviceService = deviceService;
        _companyOwnerService = companyOwnerService;
        _homeDeviceService = homeDeviceService;
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

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(
            req.Name ?? string.Empty,
            req.Model ?? string.Empty,
            req.Description ?? string.Empty,
            req.Photos ?? [],
            req.PpalPicture ?? string.Empty,
            req.IsExterior,
            req.IsInterior,
            companyOwner,
            false);

        Camera cam = _deviceService.AddCamera(args, companyOwner);

        return new CreateDeviceResponse(cam);
    }

    [HttpPost("window-sensors")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.RegisterSensor)]
    public CreateDeviceResponse RegisterSensor(CreateSensorRequest? req)
    {
        if (req == null)
        {
            throw new NullRequestException();
        }

        var isExterior = false;
        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(
            req.Name ?? string.Empty,
            req.Model ?? string.Empty,
            req.Description ?? string.Empty,
            req.Photos ?? [],
            req.PpalPicture ?? string.Empty,
            isExterior,
            true,
			companyOwner,
			false);

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

    [HttpPost("lamps")]

    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.RegisterLamp)]
    public CreateDeviceResponse RegisterLamp(CreateLampRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException();
        }

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, null, null, false, false, companyOwner ,req.Active);

        if (companyOwner == null)
        {
            throw new NotFoundException("Owner not found");
        }

        if (companyOwner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be complete");
        }

        var lamp = _deviceService.AddLamp(args, companyOwner);

        return new CreateDeviceResponse(lamp);
    }

    [HttpPost("movement-sensor")]

    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.RegisterMovementSensor)]
    public CreateDeviceResponse RegisterMovementSensor(CreateSensorRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException();
        }

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(req.Name ?? string.Empty, req.Model ?? string.Empty,
            req.Description ?? string.Empty, req.Photos ?? [], req.PpalPicture ?? string.Empty, false, false, companyOwner, false);

        if (companyOwner == null)
        {
            throw new NotFoundException("Owner not found");
        }

        if (companyOwner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be complete");
        }

        var sensor = _deviceService.AddMovementSensor(args, companyOwner);

        return new CreateDeviceResponse(sensor);
    }

    [HttpGet]
    [AuthenticationFilter]
    public List<SearchDevicesResponse> ObtainDevices([FromQuery] DeviceFiltersRequest? req)
    {
        var pageSize = 10;
        var pageOffset = 0;

        if (!string.IsNullOrEmpty(req.Limit) && int.TryParse(req.Limit, out var parsedLimit))
        {
            pageSize = parsedLimit > 0 ? parsedLimit : pageSize;
        }

        if (!string.IsNullOrEmpty(req.Offset) && int.TryParse(req.Offset, out var parsedOffset))
        {
            pageOffset = parsedOffset >= 0 ? parsedOffset : pageOffset;
        }

        var response = _deviceService
                .GetAll(req)
                .Skip(pageOffset)
                .Take(pageSize)
                .Select(d => new SearchDevicesResponse(d))
                .ToList();

        return response;
    }

    [HttpGet("supported")]
    [AuthenticationFilter]
    public List<SearchSupportedDevicesResponse> ObtainSupportedDevices()
    {
        return _deviceService
            .SearchSupportedDevices()
            .Select(d => new SearchSupportedDevicesResponse(d))
            .ToList();
    }

    [HttpPut("{hardwareId}/activate")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeDevices)]
    public TurnOnDeviceResponse TurnOnDevice([FromRoute] string hardwareId)
    {
        var user = GetUserLogged();

        var result = _homeDeviceService.Activate(hardwareId, user);
        return new TurnOnDeviceResponse(result);
    }
}
