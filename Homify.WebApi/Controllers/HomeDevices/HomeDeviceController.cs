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
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public string RenameHomeDevice(UpdateHomeDeviceRequest req, [FromRoute] string id)
    {
        Helpers.ValidateRequest(req);

        Helpers.ValidateArgsNull("CustomName", req.CustomName);

        var user = GetUserLogged();
        var device = _homeDeviceService.RenameHomeDevice(req.CustomName, id, user);

        return device.Id;
    }

    [HttpPut("{hardwareId}/activate")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeDevices)]
    public TurnOnDeviceResponse TurnOnHomeDevice([FromRoute] string hardwareId)
    {
        var user = GetUserLogged();

        var result = _homeDeviceService.Activate(hardwareId, user);
        return new TurnOnDeviceResponse(result);
    }

    [HttpPut("{hardwareId}/deactivate")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeDevices)]
    public TurnOnDeviceResponse TurnOffHomeDevice([FromRoute] string hardwareId)
    {
        var user = GetUserLogged();

        var result = _homeDeviceService.Deactivate(hardwareId, user);
        return new TurnOnDeviceResponse(result);
    }
}
