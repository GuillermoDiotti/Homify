using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Homes.Models;
using Homify.WebApi.Controllers.Homes.Models.Requests;
using Homify.WebApi.Controllers.Homes.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Homes;

[ApiController]
[Route("homes")]
public sealed class HomeController : HomifyControllerBase
{
    private readonly IHomeService _homeService;
    private readonly IUserService _userService;
    private readonly IHomeUserService _homeUserService;
    private readonly IHomePermissionService _homePermissionService;

    public HomeController(IHomeService homeService, IUserService userService, IHomeUserService homeUserService, IHomePermissionService homePermissionService)
    {
        _homeService = homeService;
        _userService = userService;
        _homeUserService = homeUserService;
        _homePermissionService = homePermissionService;
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
           request.Street ?? string.Empty,
           request.Number ?? string.Empty,
           request.Latitude ?? string.Empty,
           request.Longitud ?? string.Empty,
           request.MaxMembers, owner,
           request.Alias ?? string.Empty);

        var homeSaved = _homeService.AddHome(arguments);
        return new CreateHomeResponse(homeSaved);
    }

    [HttpPut("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeMembersList)]
    public UpdateMembersListResponse UpdateMembersList([FromRoute] string homeId, UpdateMemberListRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var home = _homeService.UpdateMemberList(homeId, request.Email);

        return new UpdateMembersListResponse(home);
    }

    [HttpPut("{homeId}/{memberId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeMembersList)]
    public HomeMemberBasicInfo ChangeHomeMemberPermissions([FromRoute] string? homeId, [FromRoute] string memberId,
        EditMemberPermissionsRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var found = _homeUserService.GetByIds(homeId, memberId);

        if (found == null)
        {
            throw new NotFoundException("HomeUser not found");
        }

        var user = GetUserLogged();
        if (user.Id != found.Home.OwnerId)
        {
            throw new InvalidOperationException("You must be the owner of this home");
        }

        var list = new List<HomePermission>();
        if (req.CanAddDevices)
        {
            var permission = _homePermissionService.GetByValue(PermissionsGenerator.MemberCanAddDevice);
            if (permission != null)
            {
                list.Add(permission);
            }
        }

        if (req.CanListDevices)
        {
            var permission = _homePermissionService.GetByValue(PermissionsGenerator.MemberCanListDevices);
            if (permission != null)
            {
                list.Add(permission);
            }
        }

        found.Permissions = list;
        var result = _homeUserService.Update(found);
        return new HomeMemberBasicInfo(result);
    }

    [HttpPut("{homeId}/devices")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeDevices)]
    public UpdateHomeDeviceResponse UpdateHomeDevice(UpdateHomeDevicesRequest request, [FromRoute] string homeId)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        if (homeId == null)
        {
            throw new NullRequestException("HomeId can not be null");
        }

        var user = GetUserLogged();

        var result = _homeService.UpdateHomeDevices(request.DeviceId, homeId, user);
        return new UpdateHomeDeviceResponse(result);
    }

    [HttpGet("{homeId}/devices")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetHomeDevices)]
    public List<GetDevicesResponse> ObtainHomeDevices([FromRoute] string homeId)
    {
        if (homeId == null)
        {
            throw new NullRequestException("HomeId can not be null");
        }

        var user = GetUserLogged();

        var list = _homeService.GetHomeDevices(homeId, user);
        var response = new List<GetDevicesResponse>();
        foreach (var hd in list)
        {
            response.Add(new GetDevicesResponse(hd));
        }

        return response;
    }

    [HttpGet("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetHomeMembers)]
    public List<GetMemberResponse> ObtainMembers([FromRoute] string homeId)
    {
        var user = GetUserLogged();
        var list = _homeService.GetHomeMembers(homeId, user);

        var responseList = list.Select(hu => new GetMemberResponse(hu)).ToList();

        return responseList;
    }

    [HttpPut("{homeId}/notifications")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeNotificatedMembers)]
    public NotificatedMembersResponse NotificatedMembers([FromRoute] string homeId, NotificatedMembersRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var user = GetUserLogged();
        var newMembersToNotify = _homeService.UpdateNotificatedList(homeId, request.HomeUserId, user);
        return new NotificatedMembersResponse(newMembersToNotify);
    }

    [HttpPatch("{homeId}/update")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public Home UpdateHome([FromRoute] string homeId, UpdateHomeRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var user = GetUserLogged();
        var result = _homeService.UpdateHome(homeId, req.Alias, user);

        return result;
    }

    [HttpGet("by-owner")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public List<GetHomesResponse> GetHomes()
    {
        var user = GetUserLogged();

        var homes = _homeService.GetAllHomes(user);
        var response = new List<GetHomesResponse>();
        foreach (var home in homes)
        {
            response.Add(new GetHomesResponse(home));
        }

        return response;
    }
}
