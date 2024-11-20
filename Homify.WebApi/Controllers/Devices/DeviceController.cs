using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Utility;
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

    public DeviceController(IDeviceService deviceService, ICompanyOwnerService companyOwnerService)
    {
        _deviceService = deviceService;
        _companyOwnerService = companyOwnerService;
    }

    [HttpPost("cameras")]
    [Authentication]
    [Authorization(PermissionsGenerator.RegisterCamera)]
    public CreateDeviceResponse RegisterCamera(CreateCameraRequest req)
    {
        Helpers.ValidateRequest(req);

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(
            req.Name ?? string.Empty,
            req.Model ?? string.Empty,
            req.Description ?? string.Empty,
            req.Photos ?? [],
            req.PpalPicture ?? string.Empty,
            req.IsExterior ?? false,
            req.IsInterior ?? false,
            req.MovementDetection ?? false,
            req.PeopleDetection ?? false,
            companyOwner,
            false);

        Camera cam = _deviceService.AddCamera(args, companyOwner);

        return new CreateDeviceResponse(cam);
    }

    [HttpPost("window-sensors")]
    [Authentication]
    [Authorization(PermissionsGenerator.RegisterSensor)]
    public CreateDeviceResponse RegisterWindowSensor(CreateSensorRequest? req)
    {
        Helpers.ValidateRequest(req);

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
            false,
            false,
            companyOwner,
            false);

        WindowSensor sen = _deviceService.AddWindowSensor(args, companyOwner);

        return new CreateDeviceResponse(sen);
    }

    [HttpPost("lamps")]
    [Authentication]
    [Authorization(PermissionsGenerator.RegisterSensor)]
    public CreateDeviceResponse RegisterLamp(CreateLampRequest req)
    {
        Helpers.ValidateRequest(req);

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(
            req.Name ?? string.Empty,
            req.Model ?? string.Empty,
            req.Description ?? string.Empty,
            req.Photos ?? [],
            null,
            false,
            false,
            false,
            false,
            companyOwner,
            req.Active);

        var lamp = _deviceService.AddLamp(args, companyOwner);

        return new CreateDeviceResponse(lamp);
    }

    [HttpPost("movement-sensors")]
    [Authentication]
    [Authorization(PermissionsGenerator.RegisterSensor)]
    public CreateDeviceResponse RegisterMovementSensor(CreateSensorRequest req)
    {
        Helpers.ValidateRequest(req);

        var user = GetUserLogged();
        var companyOwner = _companyOwnerService.GetById(user.Id);

        var args = new CreateDeviceArgs(
            req.Name ?? string.Empty,
            req.Model ?? string.Empty,
            req.Description ?? string.Empty,
            req.Photos ?? [],
            req.PpalPicture ?? string.Empty,
            false,
            false,
            false,
            false,
            companyOwner,
            false);

        var sensor = _deviceService.AddMovementSensor(args, companyOwner);

        return new CreateDeviceResponse(sensor);
    }

    [HttpGet]
    [Authentication]
    public List<SearchDevicesResponse> ObtainDevices([FromQuery] DeviceFiltersRequest? req)
    {
        var pageSize = Helpers.ValidatePaginationLimit(req.Limit);
        var pageOffset = Helpers.ValidatePaginatioOffset(req.Offset);

        var response = _deviceService
                .GetAll(req.DeviceName, req.Model, req.Company, req.Type)
                .Skip(pageOffset)
                .Take(pageSize)
                .Select(d => new SearchDevicesResponse(d))
                .ToList();

        return response;
    }

    [HttpGet("supported")]
    [Authentication]
    public List<SearchSupportedDevicesResponse> ObtainSupportedDevices()
    {
        return _deviceService
            .SearchSupportedDevices()
            .Select(d => new SearchSupportedDevicesResponse(d))
            .ToList();
    }
}
