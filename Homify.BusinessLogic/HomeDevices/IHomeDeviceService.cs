using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.HomeDevices;
public interface IHomeDeviceService
{
    HomeDevice Add(Home home, Device device);
    HomeDevice? GetByHardwareId(string? id);
    HomeDevice Activate(string hardwareId, User logged);
    HomeDevice Deactivate(string hardwareId, User logged);
    List<HomeDevice> GetByHomeId(string homeId);
    HomeDevice GetById(string id);
    HomeDevice Rename(string name, string id, User u);
    HomeDevice LampOn(string hardwareId);
    HomeDevice LampOff(string hardwareId);
    HomeDevice OpenWindow(string hardwareId);
    HomeDevice CloseWindow(string hardwareId);
}
