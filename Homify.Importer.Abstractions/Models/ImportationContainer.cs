using Newtonsoft.Json;

namespace Homify.Importer.Abstractions.Models;

public class ImportationContainer
{
    [JsonProperty("dispositivos")]
    public List<ImportedDevices>? Devices { get; set; }
}
