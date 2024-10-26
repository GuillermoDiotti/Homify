namespace Homify.WebApi.Controllers.Notifications.Models.Requests;

public sealed record class CreateNotificationRequest
{
    public string? PersonDetectedId { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
}
