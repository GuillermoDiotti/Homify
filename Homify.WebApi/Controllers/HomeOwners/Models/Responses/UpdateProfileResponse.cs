using Homify.BusinessLogic.Users.Entities;

namespace Homify.WebApi.Controllers.HomeOwners.Models.Responses;

public sealed record class UpdateProfileResponse
{
    public string User { get; set; } = null!;
    public string ProfilePicture { get; set; } = null!;

    public UpdateProfileResponse(User u)
    {
        User = u.Name + " " + u.LastName;
        ProfilePicture = u?.ProfilePicture ?? string.Empty;
    }
}
