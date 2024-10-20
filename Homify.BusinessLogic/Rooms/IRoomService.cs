using Homify.DataAccess.Repositories.Rooms.Entities;

namespace Homify.DataAccess.Repositories.Rooms;

public interface IRoomService
{
    Room AddHomeRoom(CreateRoomArgs args);
}
