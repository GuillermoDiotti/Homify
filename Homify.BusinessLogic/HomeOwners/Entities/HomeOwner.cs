using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.HomeOwners;
public class HomeOwner : User
{
    public List<Home> Homes { get; init; }

    public HomeOwner()
    {
        Homes = [];
    }
}
