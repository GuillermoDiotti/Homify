namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public sealed record class UpdateHomeDevicesRequest
{
    public string DeviceId { get; set; } = null!;
}
