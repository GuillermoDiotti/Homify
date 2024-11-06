namespace Homify.BusinessLogic.Devices.Entities;

public class CreateDeviceArgs
{
    public string Name { get; init; }
    public string Model { get; init; }
    public string Description { get; init; }
    public List<string> Photos { get; init; }
    public string PpalPicture { get; init; }
    public bool IsExterior { get; init; }
    public bool IsInterior { get; init; }
    public bool IsActive { get; init; }

    public CreateDeviceArgs(string name, string model, string description, List<string> photos, string ppalPicture, bool isExterior, bool isInterior, bool isActive)
    {
        // PpalPicture = ppalPicture;
        PpalPicture = ppalPicture ?? string.Empty;

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

        if(photos == null || photos.Count == 0)
        {
            Photos = new List<string>();
        }
        else
        {
            List<string> list = [];
            foreach (var p in photos)
            {
                list.Add(p);
            }

            Photos = list;
        }

        // List<string> list = [];
        // foreach (var p in photos)
        // {
        //     list.Add(p);
        // }

        // Photos = list;

        // Photos = photos ?? new List<string>();

        IsExterior = isExterior;
        IsInterior = isInterior;
        IsActive = isActive;
    }
}
