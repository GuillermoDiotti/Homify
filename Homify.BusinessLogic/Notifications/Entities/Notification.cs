using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Utility;

namespace Homify.BusinessLogic.Notifications.Entities;

public class Notification
{
    public string? Id { get; init; }
    public string? Event { get; init; }
    public Device? Device { get; init; }
    public bool IsRead { get; init; }
    public DateTimeOffset? Date { get; init; }

    public Notification(string? eventName, Device? device, bool isRead, DateTimeOffset? date)
    {
        Id = Guid.NewGuid().ToString();
        Event = eventName;
        Device = device;
        IsRead = isRead;
        Date = date;
    }

    public Notification()
    {
    }
}
