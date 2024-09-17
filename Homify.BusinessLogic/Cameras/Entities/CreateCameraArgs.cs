namespace Homify.BusinessLogic.Cameras.Entities;

public class CreateCameraArgs
{
    public string Name { get; init; }
    public string Model { get; init; }
    public string Description { get; init; }
    public List<string> Photos { get; init; }
    public string? PpalPicture { get; init; }

    public CreateCameraArgs(string name, string model, string description, List<string> photos, string? ppalPicture)
    {
        PpalPicture = ppalPicture;

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("name cannot be null");
        }

        Name = name;

        if (string.IsNullOrEmpty(model))
        {
            throw new ArgumentNullException("model cannot be null");
        }

        Model = model;

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException("description cannot be null");
        }

        Description = description;

        List<string> list = new ();
        foreach (var p in photos)
        {
            list.Add(p);
        }

        Photos = list;
    }
}
