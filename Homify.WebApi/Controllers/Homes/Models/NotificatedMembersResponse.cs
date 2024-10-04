using Homify.BusinessLogic.HomeUsers;

namespace Homify.WebApi.Controllers.Homes.Models;

public class NotificatedMembersResponse
{
    public List<string> MembersToNotify { get; set; } = new List<string>();

    public NotificatedMembersResponse(List<HomeUser> users)
    {
        foreach (var hu in users)
        {
            MembersToNotify.Add(hu.Id);
        }
    }
}
