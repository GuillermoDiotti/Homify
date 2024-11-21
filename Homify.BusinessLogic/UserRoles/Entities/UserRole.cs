using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.UserRoles.Entities;

public sealed record class UserRole
{
    public string Id { get; init; }
    public string? RoleId { get; set; }
    public Role? Role { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }

    public UserRole(User user, Role role)
    {
        Id = Guid.NewGuid().ToString();
        UserId = user.Id;
        RoleId = role.Id;
        User = user;
        Role = role;
    }

    public UserRole()
    {
        Id = Guid.NewGuid().ToString();
    }
}
