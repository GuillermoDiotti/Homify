using Homify.BusinessLogic.HomeDevices.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public sealed record class GetHomeDevicesResponse
{
    public string Name { get; set; } = null!;
    public string CustomName { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string? MainPhoto { get; set; } = null!;
    public bool? IsConnected { get; set; }
    public string DeviceId { get; set; } = null!;
    public string HardwareId { get; set; } = null!;
    public string Id { get; set; } = null!;
    public bool? IsActive { get; set; }
    public string Room { get; set; } = null!;
    public string DeviceType { get; set; } = null!;
    public bool? IsOn { get; set; }

    public GetHomeDevicesResponse(HomeDevice homeDevice)
    {
        Id = homeDevice.Id;
        Name = homeDevice.Device.Name;
        Model = homeDevice.Device.Model;
        IsConnected = homeDevice.Connected;
        MainPhoto = homeDevice.Device.PpalPicture;
        HardwareId = homeDevice.HardwareId;
        DeviceId = homeDevice.DeviceId;
        IsOn = homeDevice.IsOn;
        IsActive = homeDevice.IsActive;
        DeviceType = homeDevice.Device.Type;
        CustomName = homeDevice.CustomName;
        Room = homeDevice.Room == null ? string.Empty : homeDevice.Room.Name;
    }
}
