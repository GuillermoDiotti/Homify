using Homify.BusinessLogic.HomeUsers;
using Homify.Utility;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public class GetMemberResponse
{
    public string Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string? Photo { get; set; }
    public List<string> Permissions { get; set; }
    public bool MustBeNotified { get; set; }

    public GetMemberResponse(HomeUser u)
    {
        Id = u.UserId;
        Fullname = Helpers.GetUserFullName(u.User.Name, u.User.LastName);
        Email = u.User.Email;
        Permissions = u.Permissions.Select(x => x.Value).ToList();
        MustBeNotified = u.IsNotificable;
        Photo = u.User?.ProfilePicture ?? string.Empty;
    }
}
