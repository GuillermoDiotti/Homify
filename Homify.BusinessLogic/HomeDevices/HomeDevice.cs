using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes.Entities;

namespace Homify.BusinessLogic.HomeDevices;
public class HomeDevice
{
    public string Id { get; set; } = null!;
    public string HomeId { get; set; } = null!;
    public string DeviceId { get; set; } = null!;
    public Home Home { get; set; } = null!;
    public Device Device { get; set; } = null!;
    public bool Connected { get; set; }
    public string HardwareId { get; set; } = null!;
}
