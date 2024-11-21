using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;
using Homify.WebApi.Controllers.CompanyOwners.Models.Requests;
using Homify.WebApi.Controllers.CompanyOwners.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.CompanyOwners;

[ApiController]
[Route("company-owners")]
public class CompanyOwnerController : HomifyControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public CompanyOwnerController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    [HttpPost]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateCompanyOwner)]
    public CreateCompanyOwnerResponse Create(CreateCompanyOwnerRequest? request)
    {
        Helpers.ValidateRequest(request);

        var role = _roleService.Get(Constants.COMPANYOWNER);

        var arguments = new CreateUserArgs(
            request.Name ?? string.Empty,
            request.Email ?? string.Empty,
            request.Password ?? string.Empty,
            request.LastName ?? string.Empty,
            role);

        var ownerSaved = _userService.AddCompanyOwner(arguments);

        return new CreateCompanyOwnerResponse(ownerSaved);
    }
}
