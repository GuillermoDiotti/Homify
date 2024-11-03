using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.UserRoles;

public class UserRoleService : IUserRoleService
{
    private readonly IRepository<UserRole> _repository;

    public UserRoleService(IRepository<UserRole> repository)
    {
        _repository = repository;
    }

    public List<Role>? GetRolesByUserId(string userId)
    {
        try
        {
            var list = _repository.GetAll(x => x.UserId == userId).ToList();
            return list.Select(x => x.Role).ToList();
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
