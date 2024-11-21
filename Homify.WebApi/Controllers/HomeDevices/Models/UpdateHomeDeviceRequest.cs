namespace Homify.WebApi.Controllers.HomeDevices.Models;

public sealed record class UpdateHomeDeviceRequest
{
    public string CustomName { get; set; } = null!;
}
