using Homify.BusinessLogic.Roles;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Roles.Models;
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
    [Authentication]
    public RoleBasicInfo AssignRoleToExistingUser()
    {
        var user = GetUserLogged();

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        _roleService.AddRoleToUser(user);

        return new RoleBasicInfo(user);
    }
}
