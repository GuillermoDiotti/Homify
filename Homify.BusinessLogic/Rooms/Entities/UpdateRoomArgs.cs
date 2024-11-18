using Homify.BusinessLogic.HomeOwners.Entities;

namespace Homify.DataAccess.Repositories.Rooms.Entities;

public class UpdateRoomArgs
{
    public string RoomId { get; set; }
    public HomeOwner Owner { get; set; }
    public string HomeDeviceId { get; set; }

    public UpdateRoomArgs(string roomId, string homeDeviceId, HomeOwner? owner)
    {
        if (string.IsNullOrEmpty(roomId))
        {
            throw new NullReferenceException("RoomId can not be null");
        }

        if (string.IsNullOrEmpty(homeDeviceId))
        {
            throw new NullReferenceException("HomeDeviceId can not be null");
        }

        if (owner == null)
        {
            throw new NullReferenceException("Owner can not be null");
        }

        RoomId = roomId;
        HomeDeviceId = homeDeviceId;
        Owner = owner;
    }
}
