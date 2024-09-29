using Homify.BusinessLogic.Devices;

namespace Homify.BusinessLogic.Cameras.Entities;

public class Camera : Device
{
    public bool IsExterior { get; init; }
    public bool IsInterior { get; init; }

    public Camera()
        : base()
    {
    }
}
