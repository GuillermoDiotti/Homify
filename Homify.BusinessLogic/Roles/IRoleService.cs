using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Roles;

public interface IRoleService
{
    Role? Get(string roleName);
    void AddToUser(User u);
}
