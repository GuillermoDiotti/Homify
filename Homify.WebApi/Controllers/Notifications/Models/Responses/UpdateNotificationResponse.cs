using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models.Responses;

public sealed record class UpdateNotificationResponse
{
    public string Id { get; init; } = null!;
    public bool IsRead { get; init; }

    public UpdateNotificationResponse(Notification n)
    {
        Id = n.Id;
        IsRead = true;
    }
}
