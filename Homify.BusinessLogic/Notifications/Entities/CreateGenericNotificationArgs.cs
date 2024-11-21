using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.BusinessLogic.Notifications.Entities;

public class CreateGenericNotificationArgs
{
    public HomeDevice Device { get; init; }
    public bool IsRead { get; init; }
    public string? HardwareId { get; init; }
    public DateTimeOffset? Date { get; init; }
    public string? Action { get; init; }
    public string? Event { get; init; }

    public CreateGenericNotificationArgs(HomeDevice? device, bool isRead, DateTimeOffset date, string hardwareId, string? action, string? event1)
    {
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
        Action = action;
        Event = event1;
    }
}
