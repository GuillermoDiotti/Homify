namespace Homify.WebApi.Controllers.Notifications.Models.Requests;

public sealed record class CreateGenericNotificationRequest
{
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
    public string? Action { get; init; } = null!;
    public string? Event { get; init; } = null!;
}
