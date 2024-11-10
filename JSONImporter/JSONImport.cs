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
            ReturnImportDevices returnDevice = new ReturnImportDevices();
            returnDevice.Name = device.Name;
            returnDevice.Type = device.Type;
            returnDevice.Model = device.Model;
            returnDevice.Id = device.Id;
            returnDevice.PersonDetection = device.PersonDetection;
            returnDevice.MovementDetection = device.MovementDetection;
            List<ReturnPhotos> returnPhotos = new List<ReturnPhotos>();
            foreach (var photo in device.Photos)
            {
                ReturnPhotos foto = new ReturnPhotos();
                foto.Path = photo.Path;
                foto.IsPrincipal = photo.IsPrincipal;
                returnPhotos.Add(foto);
            }

            returnDevice.Photos = returnPhotos;
            returnList.Add(returnDevice);
        }

        return returnList;
    }
}
