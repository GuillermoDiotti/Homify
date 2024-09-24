using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;

namespace Homify.BusinessLogic.Devices;

public interface IDeviceService
{
    Camera AddCamera(CreateDeviceArgs device);
    Sensor AddSensor(CreateDeviceArgs device);
}
