using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Roles;

public interface IRoleService
{
    Role? GetRole(string roleName);
    void AddRoleToUser(User u);
}
