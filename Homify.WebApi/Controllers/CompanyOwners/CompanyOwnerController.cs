using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.CompanyOwners.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.CompanyOwners;

public class CompanyOwnerController
{
    private readonly IUserService _userService;

    public CompanyOwnerController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public CreateCompanyOwnerResponse Create(CreateCompanyOwnerRequest? request)
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

        var ownerSaved = _userService.AddCompanyOwner(arguments);

        return new CreateCompanyOwnerResponse(ownerSaved);
    }
}
