using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Devices;

public interface IDeviceService
{
    Camera AddCamera(CreateDeviceArgs device, User user);
    Sensor AddSensor(CreateDeviceArgs device, User user);
    Device GetById(string id);
}
