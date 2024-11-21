namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public sealed record class UpdateMemberListRequest
{
    public string Email { get; set; } = null!;
}
