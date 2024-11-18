using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Roles.Models;

public class RoleBasicInfo
{
    public string User { get; set; }
    public List<string> Roles { get; set; }

    public RoleBasicInfo(User u)
    {
        User = u.Name + " " + u.LastName;
        Roles = [];
        foreach (var s in u.Roles)
        {
            Roles.Add(s.Role.Name);
        }
    }
}
