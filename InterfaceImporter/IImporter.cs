using InterfaceImporter.Models;

namespace InterfaceImporter;

public interface IImporter
{
    string GetName();

    List<ReturnImportDevices> ImportDevices(string filePath);
}
