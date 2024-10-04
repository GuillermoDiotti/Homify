using Homify.BusinessLogic.HomeDevices;

namespace Homify.WebApi.Controllers.Homes.Models;

public sealed record class UpdateHomeDeviceResponse
{
    public string DeviceId { get; set; }

    public UpdateHomeDeviceResponse(HomeDevice homeDevice)
    {
        DeviceId = homeDevice.DeviceId;
    }
}
