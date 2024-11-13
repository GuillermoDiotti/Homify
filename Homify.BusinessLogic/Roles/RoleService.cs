using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;

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

    public void AddRoleToUser(User u)
    {
        var roles = u.Roles.Select(x => x.Role).ToList();

        if (!roles.Contains(GetRole(Constants.ADMINISTRATOR)) || !roles.Contains(GetRole(Constants.COMPANYOWNER)))
        {
            throw new InvalidOperationException("You don't have permission to add roles");
        }

        if (roles.Contains(GetRole(Constants.HOMEOWNER)))
        {
            throw new InvalidOperationException("User already has the role");
        }

        _userService.LoadIntermediateTable(u.Id, Constants.HOMEOWNERID);
    }
}
