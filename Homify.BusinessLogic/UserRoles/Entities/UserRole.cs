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

    public UserRole(User user, Role role)
    {
        UserId = user.Id;
        RoleId = role.Id;
        User = user;
        Role = role;
    }

    public UserRole()
    {
    }
}
