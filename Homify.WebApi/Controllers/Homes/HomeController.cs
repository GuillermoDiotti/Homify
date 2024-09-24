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

        var homeSaved = _homeService.AddHome(arguments);
        return new CreateHomeResponse(homeSaved);
    }

    [HttpPut("{homeId}")]
    public UpdateMembersListResponse UpdateMembersList([FromRoute] string homeId, UpdateMemberListRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
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

        _homeService.UpdateHomeDevices(request.DeviceId);
    }

    [HttpGet("{homeId}/members")]
    public List<GetMemberResponse> GetMembers([FromRoute] string homeId)
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
    public List<GetDevicesResponse> GetHomeDevices([FromRoute] string homeId)
    {
        var list = _homeService.GetHomeDevices(homeId);
        var response = new GetDevicesResponse();
        var returnList = response.Transform(list);
        return returnList;
    }
}
