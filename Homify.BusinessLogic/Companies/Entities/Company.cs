using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;

namespace Homify.BusinessLogic.Companies;

public class Company
{
    public string Id { get; init; }
    public CompanyOwner Owner { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string Rut { get; set; } = null!;

    public List<Device> Devices { get; set; } = [];

    public Company()
    {
        Id = Guid.NewGuid().ToString();
    }
}
