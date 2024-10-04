using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models;

public class CreateGenericNotificationRequest
{
    public string? Id { get; init; }
    public bool IsRead { get; init; }
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
    public string Action { get; init; } = null!;
    public DateTimeOffset Date { get; init; }
}
