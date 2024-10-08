using Homify.BusinessLogic.Devices;

namespace Homify.WebApi.Controllers.Devices.Models;

public sealed record class CreateDeviceResponse
{
    public string Id { get; init; }

    public CreateDeviceResponse(Device d)
    {
        Id = d.Id;
    }
}
