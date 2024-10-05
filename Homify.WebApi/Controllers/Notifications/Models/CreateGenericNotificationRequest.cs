namespace Homify.WebApi.Controllers.Notifications.Models;

public class CreateGenericNotificationRequest
{
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
    public string? Action { get; init; } = null!;
}
