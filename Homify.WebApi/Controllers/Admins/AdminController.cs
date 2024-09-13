using Homify.BusinessLogic.Admins;
using Homify.BusinessLogic.Admins.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var arguments = new CreateAdminArgs(
            request.Name ?? string.Empty,
            request.Email ?? string.Empty,
            request.Password ?? string.Empty,
            request.LastName ?? string.Empty);

        var adiminstratorSaved = _adminService.Add(arguments);

        return new CreateAdminResponse(adiminstratorSaved);
    }

    [HttpDelete("{adminId}")]
    public void Delete(string adminId)
    {
        var admin = _adminService.GetById(adminId);
        if (admin == null)
        {
            throw new NotFoundException("Admin not found");
        }
        else
        {
            _adminService.Delete(adminId);
        }
    }
}
