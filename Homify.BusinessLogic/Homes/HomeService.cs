using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Homes;

public class HomeService : IHomeService
{
    private readonly IRepository<Home> _repository;

    public HomeService(IRepository<Home> repository)
    {
        _repository = repository;
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

    public Home UpdateMemberList(string homeId, string mail)
    {
        throw new NotImplementedException();
    }

    public void UpdateHomeDevices(string deviceid, string homeid)
    {
        throw new NotImplementedException();
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
