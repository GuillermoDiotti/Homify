using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;

namespace Homify.BusinessLogic.Notifications.Entities;

public class CreateGenericNotificationArgs
{
    public HomeDevice Device { get; init; }
    public bool IsRead { get; init; }
    public string? HardwareId { get; init; }
    public DateTimeOffset? Date { get; init; }
    public string? Action { get; init; }

    public CreateGenericNotificationArgs(HomeDevice device, bool isRead, DateTimeOffset date, string hardwareId, string? action = null)
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
    }
}
