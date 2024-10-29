using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Permissions;
using Homify.Exceptions;
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
    [AuthorizationFilter(PermissionsGenerator.MemberCanChangeNameDevices)]
    public string UpdateHomeDevice(UpdateHomeDeviceRequest req, [FromRoute] string id)
    {
        if (req == null)
        {
            throw new NullRequestException("Request cannot null");
        }

        if(req.CustomName == null)
        {
            throw new ArgumentNullException("CustomName cannot be null");
        }

        var device = _homeDeviceService.UpdateHomeDevice(req.CustomName, id);

        return device.Id;
    }
}
