using Homify.BusinessLogic.Devices;

namespace Homify.BusinessLogic.Notifications.Entities;

public class CreateNotificationArgs
{
    public string Event { get; init; }
    public Device Device { get; init; }
    public bool IsRead { get; init; }
    public string Date { get; init; }

    public CreateNotificationArgs(string eventShot, Device device, bool isRead, string date)
    {
        if (string.IsNullOrEmpty(eventShot))
        {
            throw new ArgumentNullException("Event cannot be null");
        }

        Event = eventShot;

        ArgumentNullException.ThrowIfNull(device);

        Device = device;

        if (string.IsNullOrEmpty(date))
        {
            throw new ArgumentNullException("Date cannot be null");
        }

        Date = date;
        IsRead = isRead;
    }
}
