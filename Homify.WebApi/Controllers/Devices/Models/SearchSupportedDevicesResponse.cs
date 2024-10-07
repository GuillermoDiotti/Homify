namespace Homify.WebApi.Controllers.Devices.Models;

public class SearchSupportedDevicesResponse
{
    public string Type { get; set; } = null!;

    public SearchSupportedDevicesResponse(string type)
    {
        Type = type;
    }
}
