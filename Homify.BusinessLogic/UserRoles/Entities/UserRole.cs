using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.UserRoles.Entities;

public class UserRole
{
    public string Id = Guid.NewGuid().ToString();
    public string? RoleId { get; set; }
    public Role? Role { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
}
