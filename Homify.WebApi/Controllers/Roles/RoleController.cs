using Homify.BusinessLogic.Roles;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Roles;

[ApiController]
[Route("roles")]
public class RoleController : HomifyControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPut]
    [AuthenticationFilter]
    public IActionResult AssignRoleToExistingUser()
    {
        var user = GetUserLogged();

        if (user == null)
        {
            return Unauthorized();
        }

        _roleService.AddRoleToUser(user);

        return Ok($"Role added to {user} successfully");
    }
}
