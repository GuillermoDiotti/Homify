using Homify.BusinessLogic.HomeDevices;

namespace Homify.WebApi.Controllers.Devices.Models;

public class TurnOnDeviceResponse
{
    public string Id { get; set; }
    public bool IsActive { get; set; }

    public TurnOnDeviceResponse(HomeDevice hd)
    {
        Id = hd.Id;
        IsActive = hd.IsActive;
    }
}
