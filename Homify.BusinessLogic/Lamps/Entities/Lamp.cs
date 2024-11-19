using Homify.BusinessLogic.Devices.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Lamps.Entities;

public class Lamp : Device
{
    public Lamp()
        : base()
    {
        Type = Constants.LAMP;
        MovementDetection = false;
        PeopleDetection = false;
        WindowDetection = false;
    }
}
