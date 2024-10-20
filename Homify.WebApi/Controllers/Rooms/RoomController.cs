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
public class RoomController
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("{homeId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.CreateHome)]
    public void Create(CreateRoomRequest request, [FromRoute] string homeId)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var arguments = new CreateRoomArgs(
            homeId ?? string.Empty,
            request.Name ?? string.Empty);
    }
}
