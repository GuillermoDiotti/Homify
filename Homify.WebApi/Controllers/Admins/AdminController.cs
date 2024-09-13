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
            throw new Exception("Request is null");
        }

        return new CreateAdminResponse();
    }
}
