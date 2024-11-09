using Newtonsoft.Json;

namespace InterfaceImporter.Models;

public class ImportationContainer
{
    [JsonProperty("dispositivos")]
    public List<ImportedDevices>? Devices { get; set; }
}
