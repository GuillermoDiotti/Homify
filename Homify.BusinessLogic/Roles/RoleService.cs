using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Roles;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _repository;

    public RoleService(IRepository<Role> repository)
    {
        _repository = repository;
    }

    public Role? GetRole(string roleName)
    {
        try
        {
            return _repository.Get(x => x.Name == roleName);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
