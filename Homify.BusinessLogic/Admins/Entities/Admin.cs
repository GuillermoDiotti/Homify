using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Admins.Entities;

public sealed record class Admin : User
{
    public Admin()
        : base()
    {
    }
}
