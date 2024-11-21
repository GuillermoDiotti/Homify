using Newtonsoft.Json;

namespace Homify.Importer.Abstractions.Models;

public class ImportedDevices
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("tipo")]
    public string? Type { get; set; }
    [JsonProperty("nombre")]
    public string? Name { get; set; }
    [JsonProperty("modelo")]
    public string? Model { get; set; }
    [JsonProperty("fotos")]
    public List<ImportPhotos>? Photos { get; set; }
    [JsonProperty("person_detection")]
    public bool? PersonDetection { get; set; }
    [JsonProperty("movement_detection")]
    public bool? MovementDetection { get; set; }
}
