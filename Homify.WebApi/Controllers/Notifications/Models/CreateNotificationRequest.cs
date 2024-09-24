namespace Homify.WebApi.Controllers.Notifications.Models;

public sealed record class CreateNotificationRequest
{
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string Date { get; init; } = null!;
}
