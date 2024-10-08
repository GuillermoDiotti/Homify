using Homify.BusinessLogic.Homes.Entities;

namespace Homify.WebApi.Controllers.Homes.Models;

public class UpdateMembersListResponse
{
    public List<string> Members { get; set; } = null!;

    public UpdateMembersListResponse(Home home)
    {
        Members = home.Members.Select(x => x.Id).ToList();
    }
}
