using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.BusinessLogic.Notifications.Entities;

public class CreateNotificationArgs
{
    public string PersonDetectedId { get; init; }
    public HomeDevice Device { get; init; }
    public bool IsRead { get; init; }
    public string? HardwareId { get; init; }

    public CreateNotificationArgs(string personDetectedId, HomeDevice device, bool isRead, string hardwareId)
    {
        PersonDetectedId = personDetectedId;

        if (hardwareId == null)
        {
            throw new ArgumentException("HardwareId cannot be null");
        }

        HardwareId = hardwareId;

        ArgumentNullException.ThrowIfNull(device);

        Device = device;

        IsRead = isRead;
    }
}
