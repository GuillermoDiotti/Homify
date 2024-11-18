namespace Homify.WebApi.Controllers.HomeOwners.Models.Requests;

public sealed record class UpdateProfileRequest
{
    public string ProfilePicture { get; set; } = null!;
}
