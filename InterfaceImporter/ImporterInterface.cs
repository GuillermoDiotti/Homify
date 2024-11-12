using InterfaceImporter.Models;

namespace InterfaceImporter;

public interface ImporterInterface
{
    string GetName();

    List<ReturnImportDevices> ImportDevices(string filePath);
}
