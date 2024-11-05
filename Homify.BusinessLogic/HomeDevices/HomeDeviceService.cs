using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;
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
            CustomName = device.Name
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

    public HomeDevice Activate(string hardwareId, User logged)
    {
        var homeDevice = GetHomeDeviceByHardwareId(hardwareId);
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        var isMember = homeDevice.Home.Members.Any(x => x.UserId == logged.Id);
        var isOwner = homeDevice.Home.OwnerId == logged.Id;

        if (!isMember && !isOwner)
        {
            throw new InvalidOperationException("You are not member of this house");
        }

        homeDevice.IsActive = true;
        _repository.Update(homeDevice);
        return homeDevice;
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

        if (device == null)
        {
            throw new NotFoundException("HomeDevice not found");
        }

        device.CustomName = name;
        _repository.Update(device);

        return device;
    }
}
