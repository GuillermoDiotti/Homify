namespace InterfaceImporter.Models;

public class ReturnImportDevices
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public List<ReturnPhotos> Photos { get; set; } = null!;
    public bool? PersonDetection { get; set; }
    public bool? MovementDetection { get; set; }
}
