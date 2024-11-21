using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.BusinessLogic.HomeDevices;

public sealed class HomeDeviceService : IHomeDeviceService
{
    private readonly IRepository<HomeDevice> _repository;
    private readonly INotificationService _notificationService;

    public HomeDeviceService(IRepository<HomeDevice> repository, INotificationService notificationService)
    {
        _repository = repository;
        _notificationService = notificationService;
    }

    public HomeDevice Add(Home home, Device device)
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
            IsActive = true,
            CustomName = device.Name,
        };
        _repository.Add(homeDevice);
        return homeDevice;
    }

    public HomeDevice? GetByHardwareId(string id)
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
        var homeDevice = GetByHardwareId(hardwareId);
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

    public HomeDevice Deactivate(string hardwareId, User logged)
    {
        var homeDevice = GetByHardwareId(hardwareId);
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

        homeDevice.IsActive = false;
        _repository.Update(homeDevice);
        return homeDevice;
    }

    public List<HomeDevice> GetByHomeId(string homeId)
    {
        return _repository.GetAll(x => x.HomeId == homeId);
    }

    public HomeDevice GetById(string id)
    {
        return _repository.Get(x => x.Id == id);
    }

    public HomeDevice Rename(string name, string id, User u)
    {
        var device = GetById(id);

        if (device == null)
        {
            throw new NotFoundException("HomeDevice not found");
        }

        var home = GetByHardwareId(device.HardwareId)?.Home;

        var userIsOwner = home.OwnerId == u.Id;

        if (userIsOwner)
        {
            device.CustomName = name;
            _repository.Update(device);

            return device;
        }

        var user = home?.Members.Find(x => x.UserId == u.Id);

        if (user == null)
        {
            throw new NotFoundException("User not found in this home");
        }

        if (!user.Permissions.Any(x => x.Value == PermissionsGenerator.MemberCanChangeNameDevices))
        {
            throw new InvalidOperationException("User has no permission to rename devices");
        }

        device.CustomName = name;
        _repository.Update(device);

        return device;
    }

    public HomeDevice LampOn(string hardwareId)
    {
        var homeDevice = GetByHardwareId(hardwareId);
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (homeDevice.Device.Type != Constants.LAMP)
        {
            throw new InvalidOperationException("This device is not a lamp");
        }

        homeDevice.IsOn = true;
        CreateGenericNotificationArgs notificationArgs = new(homeDevice, false, DateTimeOffset.Now, hardwareId, "Lamp state switch detected", "Lamp On");
        _notificationService.AddLamp(notificationArgs);

        _repository.Update(homeDevice);
        return homeDevice;
    }

    public HomeDevice LampOff(string hardwareId)
    {
        var homeDevice = GetByHardwareId(hardwareId);
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (homeDevice.Device.Type != Constants.LAMP)
        {
            throw new InvalidOperationException("This device is not a lamp");
        }

        homeDevice.IsOn = false;
        CreateGenericNotificationArgs notificationArgs = new(homeDevice, false, DateTimeOffset.Now, hardwareId, "Lamp state switch detected", "Lamp Off");
        _notificationService.AddLamp(notificationArgs);
        _repository.Update(homeDevice);
        return homeDevice;
    }

    public HomeDevice OpenWindow(string hardwareId)
    {
        var homeDevice = GetByHardwareId(hardwareId);
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (homeDevice.Device.Type != Constants.SENSOR)
        {
            throw new InvalidOperationException("This device is not a window sensor");
        }

        homeDevice.IsOn = true;
        CreateGenericNotificationArgs notificationArgs = new(homeDevice, false, DateTimeOffset.Now, hardwareId, "Window state switch detected", "Window Open");
        _notificationService.AddWindow(notificationArgs);

        _repository.Update(homeDevice);
        return homeDevice;
    }

    public HomeDevice CloseWindow(string hardwareId)
    {
        var homeDevice = GetByHardwareId(hardwareId);
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (homeDevice.Device.Type != Constants.SENSOR)
        {
            throw new InvalidOperationException("This device is not a window sensor");
        }

        homeDevice.IsOn = false;
        CreateGenericNotificationArgs notificationArgs = new(homeDevice, false, DateTimeOffset.Now, hardwareId, "Window state switch detected", "Window Closed");
        _notificationService.AddWindow(notificationArgs);

        _repository.Update(homeDevice);
        return homeDevice;
    }
}
