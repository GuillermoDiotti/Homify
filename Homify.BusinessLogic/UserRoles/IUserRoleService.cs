using Homify.BusinessLogic.Roles.Entities;

namespace Homify.BusinessLogic.UserRoles;

public interface IUserRoleService
{
    List<Role>? GetRolesByUserId(string userId);
}
