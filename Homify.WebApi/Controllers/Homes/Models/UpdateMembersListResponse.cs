using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;

namespace Homify.WebApi.Controllers.Homes.Models;

public class UpdateMembersListResponse
{
    public List<HomeUser> Members { get; set; } = null!;

    public UpdateMembersListResponse(Home home)
    {
        Members = home.NofificatedMembers;
    }
}
