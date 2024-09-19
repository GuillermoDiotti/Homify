using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.Homes.Models;

public class UpdateMembersListResponse
{
    public List<User> Members { get; set; } = null!;
}
