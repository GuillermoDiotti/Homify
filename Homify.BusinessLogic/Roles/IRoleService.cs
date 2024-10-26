using Homify.BusinessLogic.Roles.Entities;

namespace Homify.BusinessLogic.Roles;

public interface IRoleService
{
    Role? GetRole(string roleName);
}
