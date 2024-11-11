using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models;

public class NotificationBasicInfo
{
    public string? Id { get; init; } = null!;
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string Date { get; init; } = null!;
    public bool IsRead { get; init; }
    public string Detail { get; init; } = null!;

    public NotificationBasicInfo(Notification noti)
    {
        Id = noti.Id;
        IsRead = noti.IsRead;
        Event = noti.Event ?? string.Empty;
        DeviceId = noti.Device?.Id ?? string.Empty;
        IsRead = noti.IsRead;
        Detail = noti.Detail ?? "-";
        Date = noti.Date ?? string.Empty;
    }
}
