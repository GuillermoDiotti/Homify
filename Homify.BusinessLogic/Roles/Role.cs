using Homify.BusinessLogic.SystemPermissions;

namespace Homify.BusinessLogic.Roles;

public class Role
{
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public List<SystemPermission> Permissions { get; init; }

    public Role(string name, List<SystemPermission> permissions)
    {
        Name = name;
        Permissions = permissions;
        Id = Guid.NewGuid().ToString();
    }

    public Role()
    {
        Permissions = [];
        Id = Guid.NewGuid().ToString();
    }
}
