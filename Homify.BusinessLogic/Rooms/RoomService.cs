using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;

namespace Homify.DataAccess.Repositories.Rooms;

public class RoomService : IRoomService
{
    private readonly IRepository<Room> _roomRepository;
    private readonly IHomeService _homeService;
    private readonly IHomeDeviceService _homeDeviceService;

    public RoomService(IRepository<Room> roomRepository, IHomeService homeService, IHomeDeviceService homeDeviceService)
    {
        _roomRepository = roomRepository;
        _homeService = homeService;
        _homeDeviceService = homeDeviceService;
    }

    public Room AddHomeRoom(CreateRoomArgs args)
    {
        var home = _homeService.GetHomeById(args.HomeId);

        if (home == null)
        {
            throw new NotFoundException("Home not found");
        }

        var duplicate = _roomRepository.Get(x => x.Name == args.Name && x.HomeId == args.HomeId);
        if (duplicate != null)
        {
            throw new InvalidOperationException("Room name already exists in that house");
        }

        if (home.Owner.Id != args.Owner.Id)
        {
            throw new InvalidOperationException("You are not the owner of this home");
        }

        var room = new Room(args.Name, home);

        _roomRepository.Add(room);
        return room;
    }

    public Room AssignHomeDeviceToRoom(UpdateRoomArgs args)
    {
        var homeDevice = _homeDeviceService.GetHomeDeviceById(args.HomeDeviceId);

        var home = homeDevice.Home;

        var room = GetRoomById(args.RoomId);

        if (!ExistsRoomHome(room, home))
        {
            throw new InvalidOperationException("The homeDevice doesn't belong to the room's home");
        }

        return null;
    }

    public bool ExistsRoomHome(Room room, Home home)
    {
        return room.Home.Equals(home);
    }

    public Room GetRoomById(string id)
    {
        return _roomRepository.Get(r => r.Id == id);
    }
}
