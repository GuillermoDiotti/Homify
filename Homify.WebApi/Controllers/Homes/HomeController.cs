﻿using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions;
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
    private readonly IHomeUserService _homeUserService;
    private readonly IHomePermissionService _homePermissionService;

    public HomeController(
        IHomeService homeService,
        IHomeUserService homeUserService,
        IHomePermissionService homePermissionService)
    {
        _homeService = homeService;
        _homeUserService = homeUserService;
        _homePermissionService = homePermissionService;
    }

    [HttpPost]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public CreateHomeResponse Create(CreateHomeRequest request)
    {
        Helpers.ValidateRequest(request);

        var owner = GetUserLogged();
        var arguments = new CreateHomeArgs(
            request.Street ?? string.Empty,
            request.Number ?? string.Empty,
            request.Latitude ?? string.Empty,
            request.Longitud ?? string.Empty,
            request.MaxMembers,
            owner,
            request.Alias ?? string.Empty);

        var homeSaved = _homeService.Add(arguments);
        return new CreateHomeResponse(homeSaved);
    }

    [HttpPut("{homeId}/members")]
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeMembersList)]
    public UpdateMembersListResponse AddMemberToHome(
        [FromRoute] string homeId,
        UpdateMemberListRequest? request)
    {
        Helpers.ValidateRequest(request);

        var home = _homeService.AddMember(homeId, request.Email);

        return new UpdateMembersListResponse(home);
    }

    [HttpPut("{homeId}/{memberId}")]
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeMembersList)]
    public HomeMemberBasicInfo ChangeHomeMemberPermissions(
        [FromRoute] string? homeId,
        [FromRoute] string memberId,
        EditMemberPermissionsRequest req)
    {
        Helpers.ValidateRequest(req);

        var found = _homeUserService.Get(homeId, memberId);

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
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeDevices)]
    public UpdateHomeDeviceResponse AssignDeviceToHome(
        UpdateHomeDevicesRequest request,
        [FromRoute] string homeId)
    {
        Helpers.ValidateRequest(request);

        var user = GetUserLogged();

        var result = _homeService.AssignDevice(request.DeviceId, homeId, user);
        return new UpdateHomeDeviceResponse(result);
    }

    [HttpGet("{homeId}/members")]
    [Authentication]
    [Authorization(PermissionsGenerator.GetHomeMembers)]
    public List<GetMemberResponse> ObtainMembers([FromRoute] string homeId)
    {
        var user = GetUserLogged();

        return _homeService
            .GetMembers(homeId, user)
            .Select(hu => new GetMemberResponse(hu))
            .ToList();
    }

    [HttpPut("{homeId}/notifications")]
    [Authentication]
    [Authorization(PermissionsGenerator.UpdateHomeNotificatedMembers)]
    public NotificatedMembersResponse UpdateNotificatedMembers(
        [FromRoute] string homeId,
        NotificatedMembersRequest request)
    {
        Helpers.ValidateRequest(request);

        var user = GetUserLogged();
        var newMembersToNotify = _homeService.UpdateNotificatedList(
            homeId,
            request.HomeUserId,
            user);
        return new NotificatedMembersResponse(newMembersToNotify);
    }

    [HttpPut("{homeId}/rename")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public UpdateHomeResponse UpdateHome([FromRoute] string homeId, UpdateHomeRequest req)
    {
        Helpers.ValidateRequest(req);

        var user = GetUserLogged();
        var result = _homeService.Update(homeId, req.Alias, user);

        return new UpdateHomeResponse(result);
    }

    [HttpGet("by-owner")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public List<GetHomesResponse> ObtainHomesWhereUserIsOwner()
    {
        var user = GetUserLogged();
        return _homeService
            .GetAllWhereUserIsOwner(user)
            .Select(home => new GetHomesResponse(home))
            .ToList();
    }

    [HttpGet("by-member")]
    [Authentication]
    [Authorization(PermissionsGenerator.CreateHome)]
    public List<GetHomesResponse> ObtainHomesWhereUserIsMember()
    {
        var user = GetUserLogged();
        return _homeService
            .GetAllWhereUserIsMember(user)
            .Select(home => new GetHomesResponse(home))
            .ToList();
    }

    [HttpGet("{homeId}/devices")]
    [Authentication]
    [Authorization(PermissionsGenerator.GetHomeDevices)]
    public List<GetHomeDevicesResponse> AllHomeDevices([FromRoute] string homeId, [FromQuery] string? room)
    {
        var user = GetUserLogged();

        var devices = _homeService.GetHomeDevices(homeId, user);

        if (!string.IsNullOrEmpty(room))
        {
            devices = devices.Where(d => d.Room != null && (d.Room?.Name.ToLower() == room.ToLower())).ToList();
        }

        return devices
            .Select(hd => new GetHomeDevicesResponse(hd))
            .ToList();
    }
}
