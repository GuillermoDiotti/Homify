using Homify.BusinessLogic.Devices;

namespace Homify.WebApi.Controllers.Devices.Models.Responses;

public class SearchDevicesResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Photo { get; set; }
    public string CompanyName { get; set; }
    public List<string> Photos { get; set; }
    public string Type { get; set; }

    public SearchDevicesResponse(Device d)
    {
        Id = d.Id;
        Name = d.Name;
        Model = d.Model;
        Photo = d.PpalPicture ?? string.Empty;
        CompanyName = d.Company.Name;
        Photos = d.Photos ?? [];
        Type = d.Type ?? string.Empty;
    }
}
