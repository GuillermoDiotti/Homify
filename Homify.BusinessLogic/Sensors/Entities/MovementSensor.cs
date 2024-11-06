using Homify.BusinessLogic.Devices;
using Homify.Utility;

namespace Homify.BusinessLogic.Sensors.Entities;

public class MovementSensor : Device
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
