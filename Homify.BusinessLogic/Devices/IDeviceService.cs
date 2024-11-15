using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Lamps.Entities;
using Homify.BusinessLogic.Sensors.Entities;

namespace Homify.BusinessLogic.Devices;

public interface IDeviceService
{
    Camera AddCamera(CreateDeviceArgs device, CompanyOwner? user);
    WindowSensor AddSWindowensor(CreateDeviceArgs device, CompanyOwner? user);
    MovementSensor AddMovementSensor(CreateDeviceArgs device, CompanyOwner? user);
    Device GetById(string id);
    List<Device> GetAll(DeviceFiltersRequest args);
    List<string> SearchSupportedDevices();
    Lamp AddLamp(CreateDeviceArgs device, CompanyOwner? user);
}
