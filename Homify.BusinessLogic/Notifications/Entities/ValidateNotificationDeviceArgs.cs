using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.Exceptions;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.BusinessLogic.Notifications.Entities;

public class ValidateNotificationDeviceArgs
{
    public HomeDevice HomeDevice;

    public ValidateNotificationDeviceArgs(HomeDevice? homeDevice, string type)
    {
        if (homeDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (homeDevice.Device.Type != type)
        {
            throw new InvalidOperationException("Selected device is not supported.");
        }

        if (!homeDevice.IsActive)
        {
            throw new InvalidOperationException("Device is not active");
        }

        HomeDevice = homeDevice;
    }
}
