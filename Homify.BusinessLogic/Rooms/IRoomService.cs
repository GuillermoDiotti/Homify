using Homify.BusinessLogic.Rooms.Entities;
using Homify.DataAccess.Repositories.Rooms.Entities;

namespace Homify.BusinessLogic.Rooms;

public interface IRoomService
{
    Room AddHomeRoom(CreateRoomArgs args);

    Room AssignHomeDeviceToRoom(UpdateRoomArgs args);

    List<Room> GetAllRooms(string homeId);
}
