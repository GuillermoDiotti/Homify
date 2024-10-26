using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Permissions.HomePermissions;

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
