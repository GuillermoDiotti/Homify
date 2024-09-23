using Homify.BusinessLogic.Devices;

namespace Homify.WebApi.Controllers.Homes.Models;

public class GetDevicesResponse
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string MainPhoto { get; set; } = null!;
    public bool IsConnected { get; set; }

    public List<GetDevicesResponse> Transform(List<Device> devices)
    {
        var returnList = new List<GetDevicesResponse>();
        foreach (var device in devices)
        {
            var newDevice = new GetDevicesResponse
            {
                Name = device.Name,
                Model = device.Model,
                IsConnected = device.IsActive,
                MainPhoto = device.Photos[0]
            };
            returnList.Add(newDevice);
        }

        return returnList;
    }
}
