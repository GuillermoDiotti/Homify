using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public class GetDevicesResponse
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string? MainPhoto { get; set; } = null!;
    public bool IsConnected { get; set; }

    public GetDevicesResponse(HomeDevice homeDevice)
    {
        Name = homeDevice.Device.Name;
        Model = homeDevice.Device.Model;
        IsConnected = homeDevice.Connected;
        MainPhoto = homeDevice.Device.PpalPicture;
    }
}
