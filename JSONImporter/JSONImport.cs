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
        var device = JsonConvert.DeserializeObject<ImportationContainer>(jsonContent);
        var devices = new List<ImportedDevices>();
        if (device.Devices != null)
        {
            devices = device.Devices.ToList();
        }

        List<ReturnImportDevices> returnList = TransformDevices(devices);
        return returnList;
    }

    public List<ReturnImportDevices> TransformDevices(List<ImportedDevices> devicesList)
    {
        var returnList = new List<ReturnImportDevices>();
        foreach (var device in devicesList)
        {
            var returnDevice = new ReturnImportDevices();
            returnDevice.Name = device.Name;
            returnDevice.Type = device.Type;
            returnDevice.Model = device.Model;
            returnDevice.Id = device.Id;
            returnDevice.PersonDetection = device.PersonDetection;
            returnDevice.MovementDetection = device.MovementDetection;
            var returnPhotos = new List<ReturnPhotos>();
            foreach (var photo in device.Photos)
            {
                var foto = new ReturnPhotos();
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
