using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.HomeDevices;

public class HomeDeviceService : IHomeDeviceService
{
    private readonly IRepository<HomeDevice> _repository;
    private readonly IHomeService _homeService;

    public HomeDeviceService(IRepository<HomeDevice> repository, IHomeService homeService)
    {
        _repository = repository;
        _homeService = homeService;
    }

    public HomeDevice? AddHomeDevice(string homeid, Device device)
    {
        var home = _homeService.GetHomeById(homeid);
        if (home == null)
        {
            throw new NotFoundException("Home not found");
        }

        var homeDevice = new HomeDevice()
        {
            HomeId = homeid,
            DeviceId = device.Id,
            Device = device,
            Home = home,
            Connected = true,
            HardwareId = Guid.NewGuid().ToString(),
            MovementDetection = false,
            PeopleDetection = false
        };
        _repository.Add(homeDevice);
        return homeDevice;
    }
}
