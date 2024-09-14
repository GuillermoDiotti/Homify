using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var arguments = new CreateUserArgs(
            request.Name ?? string.Empty,
            request.Email ?? string.Empty,
            request.Password ?? string.Empty,
            request.LastName ?? string.Empty);

        var adiminstratorSaved = _userService.Add(arguments);

        return new CreateAdminResponse(adiminstratorSaved);
    }

    [HttpDelete("{adminId}")]
    public void Delete(string adminId)
    {
        var admin = _userService.GetById(adminId);
        if (admin == null)
        {
            throw new NotFoundException("Admin not found");
        }
        else
        {
            _userService.Delete(adminId);
        }
    }

    public Admin GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new NotFoundException("Admin not found");
        }

        return _userService.GetById(id);
    }
}
