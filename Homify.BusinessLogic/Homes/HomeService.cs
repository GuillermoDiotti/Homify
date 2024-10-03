using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Homes;

public class HomeService : IHomeService
{
    private readonly IRepository<Home> _repository;
    private readonly IDeviceService _deviceService;
    private readonly IHomeDeviceService _homeDeviceService;

    public HomeService(IRepository<Home> repository, IDeviceService deviceService, IHomeDeviceService homeDeviceService)
    {
        _repository = repository;
        _deviceService = deviceService;
        _homeDeviceService = homeDeviceService;
    }

    public Home AddHome(CreateHomeArgs home)
    {
        var newHome = new Home()
        {
            Id = Guid.NewGuid().ToString(),
            Devices = [],
            Latitude = home.Latitude,
            Longitude = home.Longitude,
            Number = home.Number,
            Owner = home.Owner,
            Street = home.Street,
            MaxMembers = home.MaxMembers,
            Members = [],
            OwnerId = home.Owner.Id,
        };
        _repository.Add(newHome);
        return newHome;
    }

    public Home? GetHomeById(string id)
    {
        try
        {
            return _repository.Get(x => x.Id == id);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    public Home UpdateMemberList(string homeId, HomeUser homeOwner)
    {
        var home = _repository.Get(x => x.Id == homeId);
        home.Members.Add(homeOwner);
        _repository.Update(home);
        return home;
    }

    public void UpdateHomeDevices(string deviceid, string homeid, User user)
    {
        var home = _repository.Get(x => x.Id == homeid);
        var homeUser = home.Members.FirstOrDefault(x => x.UserId == user.Id);
        if (homeUser == null && home.OwnerId != user.Id)
        {
            throw new InvalidOperationException("User doesn't belong to this house");
        }

        var inHome = home.Members.Any(x => x.Id == user.Id);
        if (home.OwnerId == user.Id || homeUser.Permissions.Any(x => x.Value == PermissionsGenerator.MemberCanAddDevice))
        {
            var device = _deviceService.GetById(deviceid);
            if (device == null)
            {
                throw new NotFoundException("Device not found");
            }

            var homeDevice = new HomeDevice()
            {
                Device = device,
                DeviceId = device.Id,
                Home = home,
                HomeId = home.Id,
                Connected = false,
                HardwareId = Guid.NewGuid().ToString(),
                MovementDetection = false,
                PeopleDetection = false,
            };
            _homeDeviceService.AddHomeDevice(home, device);
            _repository.Update(home);
            home.Devices.Add(homeDevice);
        }
    }

    public List<User> GetHomeMembers(string id)
    {
        throw new NotImplementedException();
    }

    public void UpdateNotificatedList(string homeId, string memberId)
    {
        throw new NotImplementedException();
    }

    public List<Device> GetHomeDevices(string homeId)
    {
        throw new NotImplementedException();
    }
}
