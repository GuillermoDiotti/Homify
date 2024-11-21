using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;
using Homify.WebApi.Controllers.Admins.Models;
using Homify.WebApi.Controllers.Admins.Models.Requests;
using Homify.WebApi.Controllers.Admins.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Constants = Homify.Utility.Constants;

namespace Homify.WebApi.Controllers.Admins;

[ApiController]
[Route("admins")]
public sealed class AdminController : HomifyControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public AdminController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    [HttpPost]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateAdmin)]
    public CreateAdminResponse Create(CreateAdminRequest? request)
    {
        Helpers.ValidateRequest(request);

        var adminRole = _roleService.Get(Constants.ADMINISTRATOR);

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
    [Authentication]
    [Authorization(PermissionsGenerator.DeleteAdmin)]
    public void Delete(string adminId)
    {
        _userService.Delete(adminId);
    }

    [HttpGet("accounts")]
    [Authentication]
    [Authorization(PermissionsGenerator.GetAllAccounts)]
    public List<UserBasicInfo> AllAccounts([FromQuery] UserFiltersRequest? req)
    {
        var pageSize = 10;
        var pageOffset = 0;

        if (!string.IsNullOrEmpty(req.Limit) && int.TryParse(req.Limit, out var parsedLimit))
        {
            pageSize = parsedLimit > 0 ? parsedLimit : pageSize;
        }

        if (!string.IsNullOrEmpty(req.Offset) && int.TryParse(req.Offset, out var parsedOffset))
        {
            pageOffset = parsedOffset >= 0 ? parsedOffset : pageOffset;
        }

        return _userService
                .GetAll(req.Role, req.FullName)
                .Skip(pageOffset)
                .Take(pageSize)
                .Select(m => new UserBasicInfo(m))
                .ToList();
    }
}
