using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.HomeUsers.Entities;
public sealed record class HomeUser
{
    public string Id { get; init; } = null!;
    public Home Home { get; set; } = null!;
    public string HomeId { get; set; } = null!;
    public User User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public bool IsNotificable { get; set; }
    public List<HomePermission> Permissions { get; set; }
    public HomeUser()
    {
        Id = Guid.NewGuid().ToString();
        Permissions = [];
    }
}
