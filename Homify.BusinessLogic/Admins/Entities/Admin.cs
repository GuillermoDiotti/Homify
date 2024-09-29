using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Admins.Entities;

public class Admin : User
{
    public Admin()
        : base()
    {
        Role = RolesGenerator.Admin();
    }
}
