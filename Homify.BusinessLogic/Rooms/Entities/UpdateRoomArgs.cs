using Homify.BusinessLogic.HomeOwners;
using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class UpdateRoomArgs
{
    public string RoomId { get; set; }
    public HomeOwner Owner { get; set; }

    public UpdateRoomArgs(string roomId, HomeOwner? owner)
    {
        if (string.IsNullOrEmpty(roomId))
        {
            throw new NullReferenceException("RoomId can not be null");
        }

        if (owner == null)
        {
            throw new NullReferenceException("Owner can not be null");
        }

        RoomId = roomId;
        Owner = owner;
    }
}
