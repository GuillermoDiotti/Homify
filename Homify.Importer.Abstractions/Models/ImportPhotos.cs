using Newtonsoft.Json;

namespace Homify.Importer.Abstractions.Models;

public class ImportPhotos
{
    [JsonProperty("path")]
    public string? Path { get; set; }
    [JsonProperty("es_principal")]
    public bool IsPrincipal { get; set; }
}
