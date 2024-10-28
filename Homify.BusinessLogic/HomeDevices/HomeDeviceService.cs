using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices.Entities;
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
            Id = Guid.NewGuid().ToString(),
            HomeId = home.Id,
            DeviceId = device.Id,
            Device = device,
            Home = home,
            Connected = true,
            HardwareId = Guid.NewGuid().ToString(),
        };
        _repository.Add(homeDevice);
        return homeDevice;
    }

    public HomeDevice? GetHomeDeviceByHardwareId(string id)
    {
        try
        {
            return _repository.Get(x => x.HardwareId == id);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    public HomeDevice Activate(HomeDevice hd)
    {
        hd.IsActive = true;
        _repository.Update(hd);
        return hd;
    }

    public List<HomeDevice> GetHomeDeviceByHomeId(string homeId)
    {
        return _repository.GetAll(x => x.HomeId == homeId);
    }

    public HomeDevice GetHomeDeviceById(string id)
    {
        return _repository.Get(x => x.Id == id);
    }

    public HomeDevice UpdateHomeDevice(string name, string id)
    {
        var device = GetHomeDeviceById(id);
        if(device == null)
        {
            throw new NotFoundException("HomeDevice not found");
        }

        return null;
    }
}
