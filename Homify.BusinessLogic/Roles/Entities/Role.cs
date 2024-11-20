using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;

namespace Homify.BusinessLogic.Roles.Entities;

public sealed record class Role
{
    public string Id { get; init; } = null!;
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
