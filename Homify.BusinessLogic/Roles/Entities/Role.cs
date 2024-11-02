using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Roles.Entities;

public class Role
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<SystemPermission> Permissions { get; init; }

    public Role(string name, List<SystemPermission> permissions)
    {
        Name = name;
        Permissions = permissions;
    }

    public Role()
    {
        Permissions = [];
    }
}
