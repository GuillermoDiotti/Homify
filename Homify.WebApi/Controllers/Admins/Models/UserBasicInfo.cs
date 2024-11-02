using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;

namespace Homify.WebApi.Controllers.Admins.Models;

public class UserBasicInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }

    public string Role { get; set; }

    public string CreatedAt { get; set; }

    public UserBasicInfo(User u)
    {
        Id = u.Id;
        Name = u.Name;
        LastName = u.LastName;
        CreatedAt = u.CreatedAt;
        Role = u.Roles.Name;
        FullName = Helpers.GetUserFullName(u.Name, u.LastName);
    }
}
