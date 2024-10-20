using Homify.BusinessLogic.HomeOwners;
using Homify.DataAccess.Repositories.Rooms;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Rooms.Models;
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
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var owner = GetUserLogged() as HomeOwner;

        var arguments = new CreateRoomArgs(
            request.Name ?? string.Empty,
            homeId ?? string.Empty,
            owner);

        var room = _roomService.AddHomeRoom(arguments);
        return new CreateRoomResponse(room.Id);
    }

    [HttpPut("{roomId}/{homeDeviceId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public void AssignHomeDeviceToRoom([FromRoute] string roomId, [FromRoute] string homeDeviceId)
    {
        var owner = GetUserLogged() as HomeOwner;

        var args = new UpdateRoomArgs(
            roomId ?? string.Empty,
            owner);
    }
}
