using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Homes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Homes;

[ApiController]
[Route("homes")]
public sealed class HomeController : ControllerBase
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    [HttpPost]
    public CreateHomeResponse Create(CreateHomeRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var arguments = new CreateHomeArgs(
           request.Street ?? string.Empty, request.Number ?? string.Empty, request.Latitude ?? string.Empty,
           request.Longitud ?? string.Empty, request.MaxMembers ?? string.Empty);

        var administratorSaved = _homeService.AddHome(arguments);
        return new CreateHomeResponse(administratorSaved);
    }

    [HttpPost]
    public UpdateMembersListResponse UpdateMembersList(UpdateMemberListRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var home = _homeService.UpdateMemberList(request.Email);

        return new UpdateMembersListResponse(home);
    }

    [HttpPost]
    public void UpdateHomeDevice(UpdateHomeDevicesRequest request)
    {
        if(request == null)
        {
            throw new NullRequestException("Request can not be null");
        }
    }
}
