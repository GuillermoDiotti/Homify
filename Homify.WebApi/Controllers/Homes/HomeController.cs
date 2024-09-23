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

    [HttpPut]
    public UpdateMembersListResponse UpdateMembersList(UpdateMemberListRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var home = _homeService.UpdateMemberList(request.Email);

        return new UpdateMembersListResponse(home);
    }

    [HttpPut]
    public void UpdateHomeDevice(UpdateHomeDevicesRequest request)
    {
        if(request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        _homeService.UpdateHomeDevices(request.DeviceId);
    }

    [HttpGet]
    public List<GetMemberResponse> GetMembers()
    {
        var list = _homeService.GetHomeMembers();

        var responseList = list.Select(user => new GetMemberResponse([user])).ToList();

        return responseList;
    }

    [HttpPut]
    public void NofificatedMembers(NotificatedMembersRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        _homeService.UpdateNotificatedList(request.MemberId);
    }

    [HttpGet]
    public List<GetDevicesResponse> GetHomeDevices()
    {
        var list = _homeService.GetHomeDevices();
        var response = new GetDevicesResponse();
        var returnList = response.Transform(list);
        return returnList;
    }
}
