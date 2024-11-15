using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Permissions;
using Homify.Exceptions;
using Homify.Utility;
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
    public string UpdateHomeDevice(UpdateHomeDeviceRequest req, [FromRoute] string id)
    {
        Helpers.ValidateRequest(req);

        if (req.CustomName == null)
        {
            throw new ArgumentNullException("CustomName cannot be null");
        }

        var user = GetUserLogged();
        var device = _homeDeviceService.UpdateHomeDevice(req.CustomName, id, user);

        return device.Id;
    }
}
