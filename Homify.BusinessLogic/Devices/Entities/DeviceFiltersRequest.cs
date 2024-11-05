namespace Homify.BusinessLogic.Devices.Entities;

public class DeviceFiltersRequest
{
    public string? DeviceName { get; set; }
    public string? Model { get; set; }
    public string? Company { get; set; }
    public string? Type { get; set; }
    public string? Limit { get; set; }
    public string? Offset { get; set; }
}
