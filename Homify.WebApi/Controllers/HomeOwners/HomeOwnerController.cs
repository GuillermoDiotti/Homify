using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.Utility;
using Homify.WebApi.Controllers.HomeOwners.Models.Requests;
using Homify.WebApi.Controllers.HomeOwners.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.HomeOwners;

[ApiController]
[Route("homeowners")]
public class HomeOwnerController : HomifyControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public HomeOwnerController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    [HttpPost]
    [NonAuthenticationFilter]
    public CreateHomeOwnerResponse Create(CreateHomeOwnerRequest req)
    {
        Helpers.ValidateRequest(req);

        var role = _roleService.GetRole(Constants.HOMEOWNER);
        var args = new CreateHomeOwnerArgs(
            req.Name ?? string.Empty,
            req.Email ?? string.Empty,
            req.Password ?? string.Empty,
            req.LastName ?? string.Empty,
            req.ProfilePicUrl ?? string.Empty,
            role);

        var user = _userService.AddHomeOwner(args);

        return new CreateHomeOwnerResponse(user);
    }

    [HttpPut("profile")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public UpdateProfileResponse UpdateProfileResponse(UpdateProfileRequest req)
    {
        Helpers.ValidateRequest(req);
        var user = GetUserLogged();
        var result = _userService.UpdateProfilePicture(req.ProfilePicture ?? string.Empty, user);
        return new UpdateProfileResponse(result);
    }
}
