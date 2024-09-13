using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : ControllerBase
{
    public AdminController()
    {
    }

    [HttpPost]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        return new CreateAdminResponse();
    }
}
