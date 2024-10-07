using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;

namespace Homify.WebApi.Controllers.Admins.Models;

public class UserBasicInfo
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }

    public string Role { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public UserBasicInfo(User u)
    {
        Name = u.Name;
        LastName = u.LastName;
        CreatedAt = u.CreatedAt;
        Role = u.Role.Name;
        FullName = Helpers.GetUserFullName(u.Name, u.LastName);
    }
}
