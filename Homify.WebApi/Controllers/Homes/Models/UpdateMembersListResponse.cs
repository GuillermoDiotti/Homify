using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Homes.Models;

public class UpdateMembersListResponse
{
    public List<User> Members { get; set; } = null!;

    public UpdateMembersListResponse(Home home)
    {
        Members = home.Members;
    }
}
