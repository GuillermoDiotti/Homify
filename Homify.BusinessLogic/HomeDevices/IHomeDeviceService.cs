using Homify.BusinessLogic.Devices;

namespace Homify.BusinessLogic.HomeDevices;

public interface IHomeDeviceService
{
    HomeDevice? AddHomeDevice(string homeid, Device device);
}
