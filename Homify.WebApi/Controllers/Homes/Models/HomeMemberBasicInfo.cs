using Homify.BusinessLogic.HomeUsers;

namespace Homify.WebApi.Controllers.Homes.Models;

public class HomeMemberBasicInfo
{
    public string UserId { get; set; }
    public List<string?> Permissions { get; set; } = [];

    public HomeMemberBasicInfo(HomeUser user)
    {
        UserId = user.UserId;
        Permissions = user.Permissions.Select(x => x.ToString()).ToList();
    }
}
