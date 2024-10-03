using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Homes.Models;
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

        if (homeFound.Members.Count >= homeFound.MaxMembers)
        {
            throw new InvalidOperationException("Home members list is full");
        }

        var userFound = _userService.GetAll()
            .FirstOrDefault(x => x.Email == request.Email && x.Role.Name == Constants.HOMEOWNER);

        if (userFound == null)
        {
            throw new NotFoundException("User not found");
        }

        var userIsAlreadyInHouse = homeFound.Members.Any(m => m.UserId == userFound.Id);

        if (userIsAlreadyInHouse)
        {
            throw new InvalidOperationException("User is already in house");
        }

        var homeUser = new HomeUser()
        {
            Home = homeFound,
            IsNotificable = false,
            User = userFound,
            HomeId = homeId,
            UserId = userFound.Id,
            Permissions = [],
        };
        var home = _homeService.UpdateMemberList(homeId, homeUser);

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

        var user = GetUserLogged();

        _homeService.UpdateHomeDevices(request.DeviceId, homeId, user);
    }

    [HttpGet("{homeId}/devices")]
    public List<GetDevicesResponse> ObtainHomeDevices([FromRoute] string homeId)
    {
        var list = _homeService.GetHomeDevices(homeId);
        var response = new GetDevicesResponse();
        var returnList = response.Transform(list);
        return returnList;
    }

    [HttpGet("{homeId}/members")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetHomeMembers)]
    public List<GetMemberResponse> ObtainMembers([FromRoute] string homeId)
    {
        var user = GetUserLogged();
        var list = _homeService.GetHomeMembers(homeId, user);

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
}
