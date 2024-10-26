namespace Homify.WebApi.Controllers.Devices.Models.Responses;

public class SearchSupportedDevicesResponse
{
    public string Type { get; set; } = null!;

    public SearchSupportedDevicesResponse(string type)
    {
        Type = type;
    }
}
