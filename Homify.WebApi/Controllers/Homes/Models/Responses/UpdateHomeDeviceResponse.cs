using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public sealed record class UpdateHomeDeviceResponse
{
    public string DeviceId { get; set; }
    public string HardwareId { get; set; }
    public bool Connected { get; set; }

    public UpdateHomeDeviceResponse(HomeDevice homeDevice)
    {
        DeviceId = homeDevice.DeviceId;
        HardwareId = homeDevice.HardwareId;
        Connected = homeDevice.Connected;
    }
}
