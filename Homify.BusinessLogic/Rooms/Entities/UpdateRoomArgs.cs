using Homify.BusinessLogic.HomeOwners;
using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class UpdateRoomArgs
{
    public string RoomId { get; set; }

    public UpdateRoomArgs(string roomId)
    {
        if (string.IsNullOrEmpty(roomId))
        {
            throw new NullReferenceException("RoomId can not be null");
        }

        RoomId = roomId;
    }
}
