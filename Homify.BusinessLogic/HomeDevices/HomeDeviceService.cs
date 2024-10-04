using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.HomeDevices;

public class HomeDeviceService : IHomeDeviceService
{
    private readonly IRepository<HomeDevice> _repository;

    public HomeDeviceService(IRepository<HomeDevice> repository)
    {
        _repository = repository;
    }

    public HomeDevice AddHomeDevice(Home home, Device device)
    {
        if (home == null)
        {
            throw new NotFoundException("Home not found");
        }

        var homeDevice = new HomeDevice()
        {
            HomeId = home.Id,
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
