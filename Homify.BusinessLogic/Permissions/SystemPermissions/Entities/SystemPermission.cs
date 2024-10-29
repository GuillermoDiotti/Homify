using Homify.BusinessLogic.Roles.Entities;

namespace Homify.BusinessLogic.Permissions.SystemPermissions.Entities;

public class SystemPermission
{
    public string Id { get; init; }
    public string? Value { get; set; }

    public SystemPermission(string value)
    {
        Id = Guid.NewGuid().ToString();
        Value = value;
    }

    public SystemPermission()
    {
        Id = Guid.NewGuid().ToString();
    }

    public List<Role>? Roles { get; set; }
}
