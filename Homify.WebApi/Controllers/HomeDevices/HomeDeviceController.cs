using Homify.Exceptions;
using Homify.WebApi.Controllers.HomeDevices.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.HomeDevices;

[ApiController]
[Route("home-devices")]
public class HomeDeviceController
{
    public HomeDeviceController()
    {
    }

    [HttpPut("{id}/update")]
    [AuthenticationFilter]
    public string UpdateHomeDevice(UpdateHomeDeviceRequest req, [FromRoute] string id)
    {
        throw new NullRequestException();
    }
}
