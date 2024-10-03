using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Homes;

public class HomeService
{
    private readonly IRepository<Home> _repository;

    public HomeService(IRepository<Home> repository)
    {
        _repository = repository;
    }

    public Home AddHome(CreateHomeArgs home, HomeOwner owner)
    {
        var newHome = new Home()
        {
            Id = Guid.NewGuid().ToString(),
            Devices = [],
            Latitude = home.Latitude,
            Longitude = home.Longitude,
            Number = home.Number,
            Owner = owner,
            Street = home.Street,
            MaxMembers = home.MaxMembers,
            NofificatedMembers = [],
            OwnerId = owner.Id,
        };
        _repository.Add(newHome);
        return newHome;
    }
}
