using Homify.BusinessLogic.Companies;

namespace Homify.BusinessLogic.Devices;

public class Device
{
    public string Id { get; init; }
    public string? Type { get; set; } = null!;
    public string Name { get; init; } = null!;
    public string Model { get; init; } = null!;
    public string Description { get; init; } = null!;
    public List<string> Photos { get; init; } = null!;
    public Company Company { get; init; } = null!;
    public string? PpalPicture { get; init; }
    public string CompanyId { get; set; } = null!;
    public bool MovementDetection { get; init; }
    public bool PeopleDetection { get; init; }
    public bool WindowDetection { get; init; }

    public Device()
    {
        Id = Guid.NewGuid().ToString();
    }
}
