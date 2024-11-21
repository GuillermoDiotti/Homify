using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.BusinessLogic.Homes;

public class HomeService : IHomeService
{
    private readonly IRepository<Home> _repository;
    private readonly IDeviceService _deviceService;
    private readonly IHomeDeviceService _homeDeviceService;
    private readonly IUserService _userervice;

    public HomeService(IRepository<Home> repository, IDeviceService deviceService, IHomeDeviceService homeDeviceService, IUserService userervice)
    {
        _repository = repository;
        _deviceService = deviceService;
        _homeDeviceService = homeDeviceService;
        _userervice = userervice;
    }

    public Home Add(CreateHomeArgs home)
    {
        var homeExists = _repository.Exist(h => h.Latitude == home.Latitude && h.Longitude == home.Longitude);

        if (homeExists)
        {
            throw new DuplicatedDataException("There's already a house in this location");
        }

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
            Alias = home.Alias,
            Members = [],
            OwnerId = home.Owner.Id,
        };
        _repository.Add(newHome);
        return newHome;
    }

    public Home? GetById(string id)
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

    public Home AddMember(string homeId, string userMail)
    {
        var homeFound = GetById(homeId);

        if (homeFound == null)
        {
            throw new NotFoundException("Home not found");
        }

        if (homeFound.Members.Count >= homeFound.MaxMembers)
        {
            throw new InvalidOperationException("Home members list is full");
        }

        var userFound = _userervice.GetAll()
            .FirstOrDefault(x => x.Email == userMail && x.Roles.Any(r => r.Role.Name == Constants.HOMEOWNER));

        if (userFound == null)
        {
            throw new NotFoundException("User is not a home owner");
        }

        var userIsAlreadyInHouse = homeFound.Members.Any(m => m.UserId == userFound.Id);

        if (userIsAlreadyInHouse)
        {
            throw new InvalidOperationException("User is already in house");
        }

        var homeUser = new HomeUser()
        {
            Home = homeFound,
            IsNotificable = false,
            User = userFound,
            HomeId = homeId,
            UserId = userFound.Id,
            Permissions = [],
        };

        var home = _repository.Get(x => x.Id == homeId);
        home.Members.Add(homeUser);
        _repository.Update(home);
        return home;
    }

    public HomeDevice AssignDevice(string deviceid, string homeid, User user)
    {
        if (homeid == null)
        {
            throw new NullRequestException("HomeId can not be null");
        }

        var home = _repository.Get(x => x.Id == homeid);
        var homeUser = home.Members.FirstOrDefault(x => x.UserId == user.Id);
        if (homeUser == null && home.OwnerId != user.Id)
        {
            throw new InvalidOperationException("User doesn't belong to this house");
        }

        if (!(home.OwnerId == user.Id || homeUser.Permissions.Any(x => x.Value == PermissionsGenerator.MemberCanAddDevice)))
        {
            throw new InvalidOperationException("User doesn't belong to this house or has no permission");
        }

        var device = _deviceService.GetById(deviceid);
        if (device == null)
        {
            throw new NotFoundException("Device not found");
        }

        var result = _homeDeviceService.Add(home, device);
        home.Devices.Add(result);
        _repository.Update(home);
        return result;
    }

    public List<HomeUser> GetMembers(string homeId, User user)
    {
        var home = _repository.Get(x => x.Id == homeId);
        if (home.OwnerId != user.Id)
        {
            throw new InvalidOperationException("Only the owner can see the members");
        }

        return _repository.GetAll(x => x.Id == homeId).SelectMany(x => x.Members).ToList();
    }

    public List<HomeUser> UpdateNotificatedList(string homeId, string memberId, User owner)
    {
        var home = _repository.Get(x => x.Id == homeId);
        if (home.OwnerId != owner.Id)
        {
            throw new InvalidOperationException("Only the owner can set notificated members");
        }

        var user = home.Members.Find(x => x.UserId == memberId);
        if (user == null)
        {
            throw new InvalidOperationException("Member does not belong to the house");
        }

        user.IsNotificable = true;
        _repository.Update(home);
        return home.Members.Where(x => x.IsNotificable == true).ToList();
    }

    public List<HomeDevice> GetHomeDevices(string? homeId, User u)
    {
        if (homeId == null)
        {
            throw new NullRequestException("HomeId can not be null");
        }

        var home = _repository.Get(x => x.Id == homeId);
        var userIsOwner = home.OwnerId == u.Id;

        if (userIsOwner)
        {
            return _homeDeviceService.GetByHomeId(homeId);
        }

        var user = home.Members.FirstOrDefault(x => x.User.Id == u.Id);

        if (user == null)
        {
            throw new InvalidOperationException("User not found in this home");
        }

        if (!user.Permissions.Any(x => x.Value == PermissionsGenerator.MemberCanListDevices))
        {
            throw new InvalidOperationException("User has no permission to list devices");
        }

        return _homeDeviceService.GetByHomeId(homeId);
    }

    public Home Update(string homeId, string? alias, User u)
    {
        if (string.IsNullOrEmpty(alias))
        {
            throw new ArgumentNullException("Alias can not be null");
        }

        var home = GetById(homeId);
        if (home.OwnerId != u.Id)
        {
            throw new InvalidOperationException("Only the owner can update the home");
        }

        home.Alias = alias;
        _repository.Update(home);
        return home;
    }

    public List<Home> GetAllWhereUserIsOwner(User user)
    {
        return _repository.GetAll(x => x.OwnerId == user.Id);
    }

    public List<Home> GetAllWhereUserIsMember(User user)
    {
        return _repository.GetAll(x => x.Members.Any(m => m.UserId == user.Id));
    }
}
