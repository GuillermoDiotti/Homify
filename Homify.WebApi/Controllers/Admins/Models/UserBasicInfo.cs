using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Admins.Models;

public class UserBasicInfo
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }

    public Role Role { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public UserBasicInfo(User u)
    {
        Name = u.Name;
        LastName = u.LastName;
        FullName = u.FullName;
        CreatedAt = u.CreatedAt;
        Role = u.Role;
    }
}
