using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Admins.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Constants = Homify.Utility.Constants;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public AdminController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    [HttpPost]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateAdmin)]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var adminRole = _roleService.GetRole(Constants.ADMINISTRATOR);

        var arguments = new CreateUserArgs(
            request.Name ?? string.Empty,
            request.Email ?? string.Empty,
            request.Password ?? string.Empty,
            request.LastName ?? string.Empty,
            adminRole);

        var administratorSaved = _userService.AddAdmin(arguments);

        return new CreateAdminResponse(administratorSaved);
    }

    [HttpDelete("{adminId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.DeleteAdmin)]
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

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetAllAccounts)]
    public List<UserBasicInfo> AllAccounts([FromQuery] string limit, [FromQuery] string offset)
    {
        var pageSize = 10;
        var pageOffset = 0;

        if (!string.IsNullOrEmpty(limit) && int.TryParse(limit, out var parsedLimit))
        {
            pageSize = parsedLimit > 0 ? parsedLimit : pageSize;
        }

        if (!string.IsNullOrEmpty(offset) && int.TryParse(offset, out var parsedOffset))
        {
            pageOffset = parsedOffset >= 0 ? parsedOffset : pageOffset;
        }

        List<User> list = _userService.GetAll();
        var paginatedList = list.Skip(pageOffset).Take(pageSize).ToList();

        List<UserBasicInfo> result = [];
        foreach (User u in paginatedList)
        {
            result.Add(new UserBasicInfo(u));
        }

        return result;
    }

    public User GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new NotFoundException("Admin not found");
        }

        return _userService.GetById(id);
    }
}
