using Homify.BusinessLogic.Devices;
using Homify.Utility;

namespace Homify.DataAccess.Repositories.Lamps.Entities;

public class Lamp : Device
{
    public bool IsActive { get; set; }
    public Lamp()
        : base()
    {
        Type = Constants.LAMP;
        MovementDetection = false;
        PeopleDetection = false;
        WindowDetection = false;
    }
}
