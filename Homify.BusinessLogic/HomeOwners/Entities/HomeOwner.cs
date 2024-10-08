using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.HomeOwners;
public class HomeOwner : User
{
    public List<Home> Homes { get; init; }

    public HomeOwner()
    {
        Homes = [];
        RoleId = Constants.HOMEOWNERID;
    }
}
