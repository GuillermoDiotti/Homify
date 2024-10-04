using Homify.BusinessLogic.Devices;
using Homify.Utility;

namespace Homify.BusinessLogic.Sensors.Entities;

public class Sensor : Device
{
    public Sensor()
        : base()
    {
        Type = Constants.SENSOR;
    }
}
