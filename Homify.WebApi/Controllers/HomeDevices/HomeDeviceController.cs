using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Permissions;
using Homify.Utility;
using Homify.WebApi.Controllers.Devices.Models.Responses;
using Homify.WebApi.Controllers.HomeDevices.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.HomeDevices;

[ApiController]
[Route("home-devices")]
public class HomeDeviceController : HomifyControllerBase
{
    private readonly IHomeDeviceService _homeDeviceService;

    public HomeDeviceController(IHomeDeviceService homeDeviceService)
    {
        _homeDeviceService = homeDeviceService;
    }

    [HttpPut("{id}/update")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public string RenameHomeDevice(UpdateHomeDeviceRequest req, [FromRoute] string id)
    {
        Helpers.ValidateRequest(req);

        Helpers.ValidateArgsNull("CustomName", req.CustomName);

        var user = GetUserLogged();
        var device = _homeDeviceService.Rename(req.CustomName, id, user);

        return device.Id;
    }

    [HttpPut("{hardwareId}/activate")]
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeDevices)]
    public TurnOnDeviceResponse TurnOnHomeDevice([FromRoute] string hardwareId)
    {
        var user = GetUserLogged();

        var result = _homeDeviceService.Activate(hardwareId, user);
        return new TurnOnDeviceResponse(result);
    }

    [HttpPut("{hardwareId}/deactivate")]
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeDevices)]
    public TurnOnDeviceResponse TurnOffHomeDevice([FromRoute] string hardwareId)
    {
        var user = GetUserLogged();

        var result = _homeDeviceService.Deactivate(hardwareId, user);
        return new TurnOnDeviceResponse(result);
    }

    [HttpPut("{hardwareId}/lampOn")]
    public TurnOnOffLampResponse LampOn([FromRoute] string hardwareId)
    {
        var result = _homeDeviceService.LampOn(hardwareId);
        return new TurnOnOffLampResponse(result);
    }

    [HttpPut("{hardwareId}/lampOff")]
    public TurnOnOffLampResponse LampOff([FromRoute] string hardwareId)
    {
        var result = _homeDeviceService.LampOff(hardwareId);
        return new TurnOnOffLampResponse(result);
    }

    [HttpPut("{hardwareId}/windowOpen")]
    public OpenWindowResponse WindowOpen([FromRoute] string hardwareId)
    {
        var result = _homeDeviceService.OpenWindow(hardwareId);
        return new OpenWindowResponse(result);
    }

    [HttpPut("{hardwareId}/windowClose")]
    public OpenWindowResponse WindowClose([FromRoute] string hardwareId)
    {
        var result = _homeDeviceService.CloseWindow(hardwareId);
        return new OpenWindowResponse(result);
    }
}
