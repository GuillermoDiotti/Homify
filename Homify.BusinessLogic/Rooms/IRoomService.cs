using Homify.BusinessLogic.Rooms.Entities;

namespace Homify.BusinessLogic.Rooms;

public interface IRoomService
{
    Room Add(CreateRoomArgs args);

    Room AssignHomeDevice(UpdateRoomArgs args);

    List<Room> GetAll(string homeId);
}
