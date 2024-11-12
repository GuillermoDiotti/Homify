using Newtonsoft.Json;

namespace InterfaceImporter.Models;

public class ImportPhotos
{
    [JsonProperty("path")]
    public string? Path { get; set; }
    [JsonProperty("es_principal")]
    public bool IsPrincipal { get; set; }
}
