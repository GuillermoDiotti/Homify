using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.HomeDevices.Models;

public class TurnOnOffLampResponse
{
    public string Id { get; set; } = null!;
    public bool IsOn { get; set; }

    public TurnOnOffLampResponse(HomeDevice hd)
    {
        Id = hd.Id;
        IsOn = hd.IsOn;
    }
}
