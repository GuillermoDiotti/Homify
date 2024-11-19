using Homify.BusinessLogic.Devices.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Cameras.Entities;

public class Camera : Device
{
    public bool? IsExterior { get; init; }
    public bool? IsInterior { get; init; }

    public Camera()
        : base()
    {
        Type = Constants.CAMERA;
        WindowDetection = false;
    }

    public Camera(bool movementDetection, bool peopleDetection)
        : base()
    {
        Type = Constants.CAMERA;
        MovementDetection = movementDetection;
        PeopleDetection = peopleDetection;
        WindowDetection = false;
    }
}
