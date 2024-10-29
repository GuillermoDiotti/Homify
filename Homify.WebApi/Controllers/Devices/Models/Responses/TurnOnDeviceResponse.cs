using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.Devices.Models.Responses;

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
