using Homify.BusinessLogic.Devices.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Sensors.Entities;

public sealed record class MovementSensor : Device
{
    public MovementSensor()
        : base()
    {
        Type = Constants.MOVEMENTSENSOR;
        MovementDetection = true;
        PeopleDetection = false;
        WindowDetection = false;
    }
}
