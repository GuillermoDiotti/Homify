using Homify.BusinessLogic.HomeUsers;

namespace Homify.BusinessLogic.Permissions.HomePermissions.Entities;
public class HomePermission
{
    public string Id { get; set; } = null!;
    public string Value { get; set; } = null!;
    public List<HomeUser>? HomeUsers { get; set; }

    public HomePermission()
    {
        Id = Guid.NewGuid().ToString();
    }
}
