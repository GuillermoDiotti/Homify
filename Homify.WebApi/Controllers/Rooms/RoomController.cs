using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Rooms;
using Homify.BusinessLogic.Rooms.Entities;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Rooms.Models;
using Homify.WebApi.Controllers.Rooms.Models.Requests;
using Homify.WebApi.Controllers.Rooms.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Rooms;

[ApiController]
[Route("rooms")]
public class RoomController : HomifyControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("{homeId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public CreateRoomResponse Create(CreateRoomRequest request, [FromRoute] string homeId)
    {
        Helpers.ValidateRequest(request);

        var owner = GetUserLogged() as HomeOwner;

        var arguments = new CreateRoomArgs(
            request.Name ?? string.Empty,
            homeId ?? string.Empty,
            owner);

        var room = _roomService.AddHomeRoom(arguments);
        return new CreateRoomResponse(room.Id);
    }

    [HttpPost("{homeId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public List<RoomBasicInfo> ObtainHomeRooms([FromRoute] string homeId)
    {
        return _roomService
            .GetAllRooms(homeId)
            .Select(r => new RoomBasicInfo(r))
            .ToList();
    }

    [HttpPut("{roomId}/{homeDeviceId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public Room AssignHomeDeviceToRoom([FromRoute] string roomId, [FromRoute] string homeDeviceId)
    {
        var owner = GetUserLogged() as HomeOwner;

        var args = new UpdateRoomArgs(
            roomId ?? string.Empty,
            homeDeviceId ?? string.Empty,
            owner);

        var result = _roomService.AssignHomeDeviceToRoom(args);

        return result;
    }
}
