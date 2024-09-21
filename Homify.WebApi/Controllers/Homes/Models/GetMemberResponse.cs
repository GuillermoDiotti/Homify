using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Homes.Models;

public class GetMemberResponse
{
    public List<User> Members { get; set; } = null!;

    public GetMemberResponse(List<User> members)
    {
        Members = members;
    }
}
