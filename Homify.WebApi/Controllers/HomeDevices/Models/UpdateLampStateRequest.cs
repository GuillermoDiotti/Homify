namespace Homify.WebApi.Controllers.HomeDevices.Models;

public sealed record class UpdateLampStateRequest
{
    public bool IsOn { get; set; }
}
