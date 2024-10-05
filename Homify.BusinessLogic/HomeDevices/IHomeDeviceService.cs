using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes.Entities;

namespace Homify.BusinessLogic.HomeDevices;
public interface IHomeDeviceService
{
    HomeDevice AddHomeDevice(Home home, Device device);
    HomeDevice? GetHomeDeviceByHardwareId(string? id);
    HomeDevice Activate(HomeDevice hd);
}
