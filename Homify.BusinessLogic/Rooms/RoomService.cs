using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Homes;
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

        return null;
    }

    public Room AssignHomeDeviceToRoom(UpdateRoomArgs args)
    {
        throw new NotImplementedException();
    }
}
