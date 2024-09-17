using Homify.BusinessLogic.Cameras.Entities;

namespace Homify.BusinessLogic.Devices;

public interface IDeviceService
{
    Camera AddCamera(CreateCameraArgs camera);
}
