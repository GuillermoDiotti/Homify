namespace Homify.BusinessLogic.Devices.Entities;

public class SearchDevicesArgs
{
    public string? DeviceName { get; set; }
    public string? Model { get; set; }
    public string? Company { get; set; }
    public string? Type { get; set; }
    public int Limit { get; set; } = 10;
    public int Offset { get; set; } = 0;
}
