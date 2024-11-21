namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public sealed record class NotificatedMembersRequest
{
    public string HomeUserId { get; set; } = null!;
}
