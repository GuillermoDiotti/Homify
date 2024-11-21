using Homify.Importer.Abstractions.Models;

namespace Homify.Importer.Abstractions;

public interface IImporter
{
    string GetName();

    List<ReturnImportDevices> ImportDevices(string filePath);
}
