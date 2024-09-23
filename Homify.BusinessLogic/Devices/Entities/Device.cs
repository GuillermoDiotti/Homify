using Homify.BusinessLogic.Companies;

namespace Homify.BusinessLogic.Devices;

public class Device
{
    public string Id { get; init; }
    public string Name { get; init; } = null!;
    public string Model { get; init; } = null!;
    public string Description { get; init; } = null!;
    public List<string> Photos { get; init; } = null!;
    public Company Company { get; init; } = null!;
    public string? PpalPicture { get; init; }
    public bool IsActive { get; set; }

    public Device()
    {
        Id = Guid.NewGuid().ToString();
        IsActive = false;
    }
}
