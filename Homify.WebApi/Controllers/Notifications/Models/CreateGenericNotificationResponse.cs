using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models;

public sealed record class CreateGenericNotificationResponse
{
    public string? Id { get; init; }
    public bool IsRead { get; init; }
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
    public DateTimeOffset Date { get; init; }

    public CreateGenericNotificationResponse(Notification n)
    {
        Id = n.Id;
        IsRead = n.IsRead;
        Event = n.Event;
        DeviceId = n.HomeDeviceId;
        HardwareId = n.Device!.HardwareId;
        Date = n.Date!.Value;
    }
}
