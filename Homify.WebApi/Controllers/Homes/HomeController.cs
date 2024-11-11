using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
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

    public HomeController(
        IHomeService homeService,
        IUserService userService,
        IHomeUserService homeUserService,
        IHomePermissionService homePermissionService)
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
            request.MaxMembers,
            owner,
            request.Alias ?? string.Empty);

        var homeSaved = _homeService.AddHome(arguments);
        return new CreateHomeResponse(homeSaved);
    }

    [HttpPut("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeMembersList)]
    public UpdateMembersListResponse UpdateMembersList(
        [FromRoute] string homeId,
        UpdateMemberListRequest? request)
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
    public HomeMemberBasicInfo ChangeHomeMemberPermissions(
        [FromRoute] string? homeId,
        [FromRoute] string memberId,
        EditMemberPermissionsRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var found = _homeUserService.GetByIds(homeId, memberId);

        var user = GetUserLogged();

        var list = _homePermissionService.ChangeHomeMemberPermissions(
            req.CanAddDevices,
            req.CanListDevices,
            req.CanRenameDevices,
            user,
            found);

        found.Permissions = list;
        var result = _homeUserService.Update(found);
        return new HomeMemberBasicInfo(result);
    }

    [HttpPut("{homeId}/devices")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeDevices)]
    public UpdateHomeDeviceResponse UpdateHomeDevice(
        UpdateHomeDevicesRequest request,
        [FromRoute] string homeId)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
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
        var user = GetUserLogged();

        return _homeService
            .GetHomeDevices(homeId, user)
            .Select(hd => new GetDevicesResponse(hd))
            .ToList();
    }

    [HttpGet("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetHomeMembers)]
    public List<GetMemberResponse> ObtainMembers([FromRoute] string homeId)
    {
        var user = GetUserLogged();

        return _homeService
            .GetHomeMembers(homeId, user)
            .Select(hu => new GetMemberResponse(hu))
            .ToList();
    }

    [HttpPut("{homeId}/notifications")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateHomeNotificatedMembers)]
    public NotificatedMembersResponse NotificatedMembers(
        [FromRoute] string homeId,
        NotificatedMembersRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var user = GetUserLogged();
        var newMembersToNotify = _homeService.UpdateNotificatedList(
            homeId,
            request.HomeUserId,
            user);
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
    public List<GetHomesResponse> ObtainHomesWhereUserIsOwner()
    {
        var user = GetUserLogged();
        return _homeService
            .GetAllHomesWhereUserIsOwner(user)
            .Select(home => new GetHomesResponse(home))
            .ToList();
    }

    [HttpGet("by-member")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public List<GetHomesResponse> ObtainHomesWhereUserIsMember()
    {
        var user = GetUserLogged();
        return _homeService
            .GetAllHomesWhereUserIsMember(user)
            .Select(home => new GetHomesResponse(home))
            .ToList();
    }
}
