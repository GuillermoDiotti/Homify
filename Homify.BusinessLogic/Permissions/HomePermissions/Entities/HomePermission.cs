using Homify.BusinessLogic.HomeUsers.Entities;

namespace Homify.BusinessLogic.Permissions.HomePermissions.Entities;
public sealed record class HomePermission
{
    public string Id { get; init; } = null!;
    public string Value { get; set; } = null!;
    public List<HomeUser>? HomeUsers { get; set; }

    public HomePermission()
    {
        Id = Guid.NewGuid().ToString();
    }
}
