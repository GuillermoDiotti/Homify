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

    // TODO: public List<IObserver> MembersToNotify { get; init; }

    public Device(string name, string model, string description, List<string> photos, Company company, string? pictureUrl)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Model = model;
        Description = description;
        Photos = photos;
        Company = company;
        PpalPicture = pictureUrl;
    }

    public Device()
    {
        Id = Guid.NewGuid().ToString();
    }
}
