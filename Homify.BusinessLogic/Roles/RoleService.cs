using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.BusinessLogic.Roles;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _repository;
    private readonly IUserService _userService;

    public RoleService(IRepository<Role> repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public Role? Get(string roleName)
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

    public void AddToUser(User u)
    {
        var roles = u.Roles.Select(x => x.Role).ToList();

        if (!roles.Contains(Get(Constants.ADMINISTRATOR)) && !roles.Contains(Get(Constants.COMPANYOWNER)))
        {
            throw new InvalidOperationException("User must be an admin or company owner to add a role.");
        }

        if (roles.Contains(Get(Constants.HOMEOWNER)))
        {
            throw new InvalidOperationException("User has already the HomeOwner Role");
        }

        _userService.LoadIntermediateTable(u.Id, Constants.HOMEOWNERID);
    }
}
