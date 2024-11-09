using InterfaceImporter;
using InterfaceImporter.Models;
using Newtonsoft.Json;

namespace JSONImporter;

public class JSONImport : ImporterInterface
{
    public string GetName()
    {
        return "Json importer";
    }

    public List<ReturnImportDevices> ImportDevices(string filePath)
    {
        var jsonContent = File.ReadAllText("ImportDevices/" + filePath);
        var build = JsonConvert.DeserializeObject<ImportationContainer>(jsonContent);
        var buildings = new List<ImportedDevices>();
        if (build.Devices != null)
        {
            buildings = build.Devices.ToList();
        }

        List<ReturnImportDevices> returnList = TransformBuildings(buildings);
        return returnList;
    }

    public List<ReturnImportDevices> TransformBuildings(List<ImportedDevices> devicesList)
    {
        List<ReturnImportDevices> returnList = new List<ReturnImportDevices>();
        foreach (var device in devicesList)
        {
            // ReturnImportDevices returnDevice = new ReturnImportDevices();
            // returnDevice.Name = device.Name;
            // returnDevice.Type = device.Type;
            // returnDevice.Brand = device.Brand;
            // returnDevice.Model = device.Model;
            // returnDevice.Price = device.Price;
            // returnDevice.Warranty = device.Warranty;
            // returnDevice.DateOfPurchase = device.DateOfPurchase;
            // returnDevice.Owner = device.Owner;
            // returnList.Add(returnDevice);
        }

        return returnList;
    }
}
