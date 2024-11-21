using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.HomeDevices.Models;

public class OpenWindowResponse
{
    public string Id { get; set; } = null!;
    public bool IsOn { get; set; }

    public OpenWindowResponse(HomeDevice hd)
    {
        Id = hd.Id;
        IsOn = hd.IsOn;
    }
}
