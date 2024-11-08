using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Devices.Entities;

public class CreateDeviceArgs
{
    public string Name { get; init; }
    public string Model { get; init; }
    public string Description { get; init; }
    public List<string> Photos { get; init; }
    public string? PpalPicture { get; init; }
    public bool IsExterior { get; init; }
    public bool IsInterior { get; init; }
    public CompanyOwner Owner { get; init; }

    public CreateDeviceArgs(string name, string model, string description, List<string> photos, string? ppalPicture, bool isExterior, bool isInterior, CompanyOwner? owner)
    {
        PpalPicture = ppalPicture;

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(name, "name cannot be null");
        }

        Name = name;

        if (string.IsNullOrEmpty(model))
        {
            throw new ArgumentNullException(model, "model cannot be null");
        }

        Model = model;

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(description, "description cannot be null");
        }

        Description = description;

        List<string> list = [];
        foreach (var p in photos)
        {
            list.Add(p);
        }

        Photos = list;
        IsExterior = isExterior;
        IsInterior = isInterior;

        if (owner == null)
        {
            throw new NotFoundException("Owner not found");
        }

        if (owner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be complete");
        }

        Owner = owner;
    }
}
