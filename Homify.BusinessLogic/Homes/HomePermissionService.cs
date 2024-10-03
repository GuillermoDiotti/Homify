using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Homes;

public class HomePermissionService : IHomePermissionService
{
    private readonly IRepository<HomePermission> _repository;

    public HomePermissionService(IRepository<HomePermission> repository)
    {
        _repository = repository;
    }

    public HomePermission? GetByValue(string value)
    {
        return _repository.Get(x => x.Value == value);
    }
}
