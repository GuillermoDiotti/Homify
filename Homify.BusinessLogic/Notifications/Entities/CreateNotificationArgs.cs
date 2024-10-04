using Homify.BusinessLogic.Devices;

namespace Homify.BusinessLogic.Notifications.Entities;

public class CreateNotificationArgs
{
    public string PersonDetectedId { get; init; }
    public Device Device { get; init; }
    public bool IsRead { get; init; }
    public string? HardwareId { get; init; }
    public DateTimeOffset? Date { get; init; }

    public CreateNotificationArgs(string personDetectedId, Device device, bool isRead, DateTimeOffset date, string hardwareId)
    {
        if (string.IsNullOrEmpty(personDetectedId))
        {
            throw new ArgumentNullException("PersonDetectedId cannot be null or empty");
        }

        PersonDetectedId = personDetectedId;

        if (hardwareId == null)
        {
            throw new ArgumentException("HardwareId cannot be null");
        }

        HardwareId = hardwareId;

        ArgumentNullException.ThrowIfNull(device);

        Device = device;

        if (date == null)
        {
            throw new ArgumentNullException("Date cannot be null");
        }

        Date = date;
        IsRead = isRead;
    }
}
