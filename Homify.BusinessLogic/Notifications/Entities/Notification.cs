using Homify.BusinessLogic.HomeDevices;

namespace Homify.BusinessLogic.Notifications.Entities;

public class Notification
{
    public string? Id { get; init; }
    public string? Event { get; init; }
    public HomeDevice? Device { get; init; }
    public string HomeDeviceId { get; init; } = null!;
    public bool IsRead { get; init; }
    public DateTimeOffset? Date { get; init; }
    public string? PersonId { get; init; } = null!;

    public Notification(string? eventName, HomeDevice device, bool isRead, DateTimeOffset? date, string personId)
    {
        Id = Guid.NewGuid().ToString();
        Event = eventName;
        Device = device;
        IsRead = isRead;
        Date = date;
        HomeDeviceId = device.Id;
        PersonId = personId;
    }

    public Notification()
    {
    }
}
