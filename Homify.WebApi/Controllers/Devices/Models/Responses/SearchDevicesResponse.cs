using Homify.BusinessLogic.Devices;

namespace Homify.WebApi.Controllers.Devices.Models.Responses;

public class SearchDevicesResponse
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Photo { get; set; }
    public string CompanyName { get; set; }

    public SearchDevicesResponse(Device d)
    {
        Name = d.Name;
        Model = d.Model;
        Photo = d.PpalPicture ?? string.Empty;
        CompanyName = d.Company.Name;
    }
}
