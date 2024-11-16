using Homify.Exceptions;

namespace Homify.BusinessLogic.HomeUsers;

public class HomeUserService : IHomeUserService
{
    private readonly IRepository<HomeUser> _repository;

    public HomeUserService(IRepository<HomeUser> repository)
    {
        _repository = repository;
    }

    public HomeUser? GetHomeUser(string? homeId, string? userId)
    {
        var response = _repository.Get(x => x.HomeId == homeId && x.UserId == userId);

        if (response == null)
        {
            throw new NotFoundException("HomeUser not found");
        }

        return response;
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
