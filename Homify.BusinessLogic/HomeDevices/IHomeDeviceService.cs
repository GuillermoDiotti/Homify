using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.HomeDevices;
public interface IHomeDeviceService
{
    HomeDevice AddHomeDevice(Home home, Device device);
    HomeDevice? GetHomeDeviceByHardwareId(string? id);
    HomeDevice Activate(string hardwareId, User logged);
    HomeDevice Deactivate(string hardwareId, User logged);
    List<HomeDevice> GetHomeDeviceByHomeId(string homeId);
    HomeDevice GetHomeDeviceById(string id);

    HomeDevice UpdateHomeDevice(string name, string id, User u);
}
