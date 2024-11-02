using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers;
using Homify.WebApi.Controllers.HomeOwners.Models.Requests;
using Homify.WebApi.Controllers.HomeOwners.Models.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi;

[ApiController]
[Route("borrador")]
public class Borrador : HomifyControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IRepository<UserRole> _repository;

    public Borrador(IUserService userService, IRoleService roleService, IRepository<UserRole> repository)
    {
        _userService = userService;
        _roleService = roleService;
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Create(Request req)
    {
        var role = new UserRole() { UserId = req.UserId, RoleId = Constants.HOMEOWNERID };

        _repository.Add(role);
        return Ok("creado");
    }
}

public class Request
{
    public string? UserId { get; set; }
}
