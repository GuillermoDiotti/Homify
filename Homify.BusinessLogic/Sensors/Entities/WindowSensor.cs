using Homify.BusinessLogic.Devices.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Sensors.Entities;

public sealed record class WindowSensor : Device
{
    public WindowSensor()
        : base()
    {
        Type = Constants.SENSOR;
        MovementDetection = false;
        PeopleDetection = false;
        WindowDetection = true;
    }
}
