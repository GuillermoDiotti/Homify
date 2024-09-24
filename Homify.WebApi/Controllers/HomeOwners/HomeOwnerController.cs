using Homify.BusinessLogic.HouseOwner.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.HomeOwners.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.HomeOwners;

[ApiController]
[Route("homeowners")]
public class HomeOwnerController
{
    private readonly IUserService _userService;

    public HomeOwnerController(IUserService userService)
    {
        _userService = userService;
    }

    public CreateHomeOwnerResponse Create(CreateHomeOwnerRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request cannot be null");
        }

        var args = new CreateHomeOwnerArgs(req.Name ?? string.Empty, req.Email ?? string.Empty, req.Password ?? string.Empty,
            req.LastName ?? string.Empty, req.ProfilePicUrl ?? string.Empty);
        var user = _userService.AddHomeOwner(args);

        return new CreateHomeOwnerResponse(user);
    }
}
