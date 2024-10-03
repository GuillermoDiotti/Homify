using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Homes.Models;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Homes;

[ApiController]
[Route("homes")]
public sealed class HomeController : HomifyControllerBase
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    [HttpPost]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public CreateHomeResponse Create(CreateHomeRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var owner = GetUserLogged() as HomeOwner;
        var arguments = new CreateHomeArgs(
           request.Street ?? string.Empty, request.Number ?? string.Empty, request.Latitude ?? string.Empty,
           request.Longitud ?? string.Empty, request.MaxMembers, owner);

        var homeSaved = _homeService.AddHome(arguments);
        return new CreateHomeResponse(homeSaved);
    }

    [HttpPut("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeMembersList)]
    public UpdateMembersListResponse UpdateMembersList([FromRoute] string homeId, UpdateMemberListRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var homeFound = _homeService.GetHomeById(homeId);

        if (homeFound == null)
        {
            throw new NotFoundException("Home not found");
        }

        if (homeFound.MaxMembers >= homeFound.Members.Count)
        {
            throw new InvalidOperationException("Home members list is full");
        }

        var home = _homeService.UpdateMemberList(homeId, request.Email);

        return new UpdateMembersListResponse(home);
    }

    [HttpPut("{homeId}/devices")]
    public void UpdateHomeDevice(UpdateHomeDevicesRequest request, [FromRoute] string homeId)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        if (homeId == null)
        {
            throw new NullRequestException("HomeId can not be null");
        }

        _homeService.UpdateHomeDevices(request.DeviceId, homeId);
    }

    [HttpGet("{homeId}/members")]
    public List<GetMemberResponse> ObtainMembers([FromRoute] string homeId)
    {
        var list = _homeService.GetHomeMembers(homeId);

        var responseList = list.Select(user => new GetMemberResponse([user])).ToList();

        return responseList;
    }

    [HttpPut("{homeId}/notifications")]
    public void NotificatedMembers([FromRoute] string homeId, NotificatedMembersRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        _homeService.UpdateNotificatedList(homeId, request.MemberId);
    }

    [HttpGet("{homeId}/devices")]
    public List<GetDevicesResponse> ObtainHomeDevices([FromRoute] string homeId)
    {
        var list = _homeService.GetHomeDevices(homeId);
        var response = new GetDevicesResponse();
        var returnList = response.Transform(list);
        return returnList;
    }
}
