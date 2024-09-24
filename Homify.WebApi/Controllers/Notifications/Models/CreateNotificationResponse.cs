using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models;

public sealed record class CreateNotificationResponse
{
    public string? Id { get; init; }
    public bool IsRead { get; init; }

    public CreateNotificationResponse(Notification n)
    {
        Id = n.Id;
        IsRead = n.IsRead;
    }
}
