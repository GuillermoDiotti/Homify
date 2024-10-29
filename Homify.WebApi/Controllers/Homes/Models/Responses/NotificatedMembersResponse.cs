using Homify.BusinessLogic.HomeUsers;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public class NotificatedMembersResponse
{
    public List<string> MembersToNotify { get; set; } = [];

    public NotificatedMembersResponse(List<HomeUser> users)
    {
        foreach (var hu in users)
        {
            MembersToNotify.Add(hu.Id);
        }
    }
}
