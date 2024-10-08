namespace Homify.WebApi.Controllers.Notifications.Models;

public sealed record class CreateNotificationRequest
{
    public string? PersonDetectedId { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
}
