using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models;

public class NotificationBasicInfo
{
    public string? Id { get; init; } = null!;
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string Date { get; init; } = null!;
    public bool IsRead { get; init; }

    public NotificationBasicInfo(Notification noti)
    {
        Id = noti.Id;
        IsRead = noti.IsRead;
        Event = noti.Event;
        DeviceId = noti.Device.Id;
        IsRead = noti.IsRead;
    }
}
