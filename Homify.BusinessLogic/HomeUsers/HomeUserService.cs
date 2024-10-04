using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.HomeUsers;

public class HomeUserService : IHomeUserService
{
    private readonly IRepository<HomeUser> _repository;

    public HomeUserService(IRepository<HomeUser> repository)
    {
        _repository = repository;
    }

    public HomeUser? GetByIds(string? homeId, string? userId)
    {
        return _repository.Get(x => x.HomeId == homeId && x.UserId == userId);
    }

    public HomeUser Update(HomeUser hu)
    {
        _repository.Update(hu);
        return hu;
    }

    public List<HomeUser> GetHomeUsersByHomeId(string id)
    {
        return _repository.GetAll(x => x.HomeId == id);
    }
}
