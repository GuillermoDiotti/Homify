using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.HomeOwners.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.HomeOwners;

[ApiController]
[Route("homeowners")]
public class HomeOwnerController
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly ISessionService _sessionService;

    public HomeOwnerController(IUserService userService, IRoleService roleService, ISessionService sessionService)
    {
        _userService = userService;
        _roleService = roleService;
        _sessionService = sessionService;
    }

    public CreateHomeOwnerResponse Create(CreateHomeOwnerRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var role = _roleService.GetRole(Constants.HOMEOWNER);
        var args = new CreateHomeOwnerArgs(req.Name ?? string.Empty, req.Email ?? string.Empty, req.Password ?? string.Empty,
            req.LastName ?? string.Empty, req.ProfilePicUrl ?? string.Empty, role);
        var user = _userService.AddHomeOwner(args);
        _sessionService.CreateSession(user);
        return new CreateHomeOwnerResponse(user);
    }
}
