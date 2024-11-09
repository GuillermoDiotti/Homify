using System.Reflection;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories.Importers.Entities;
using InterfaceImporter;
using InterfaceImporter.Models;

namespace Homify.DataAccess.Repositories.Importers;

public class ImporterService : IImporterService
{
    public List<ImporterInterface> GetAllImporters()
    {
        var importersPath = "./Importers";
        var filePaths = Directory.GetFiles(importersPath);

        List<ImporterInterface> availableImporters = new List<ImporterInterface>();

        foreach (var file in filePaths)
        {
            if (FileIsDll(file))
            {
                FileInfo dllFile = new FileInfo(file);
                Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);

                foreach (Type type in myAssembly.GetTypes())
                {
                    if (ImplementsRequiredInterface(type))
                    {
                        ImporterInterface instance = (ImporterInterface)Activator.CreateInstance(type);
                        if (instance != null)
                        {
                            availableImporters.Add(instance);
                        }
                    }
                }
            }
        }

        return availableImporters;
    }

    public void AddImportedDevices(ImporterArgs args, User user)
    {
        ImporterInterface? importerFile = GetAllImporters()
            .FirstOrDefault(i => i.GetName().Equals(args.Importer, StringComparison.OrdinalIgnoreCase));

        if (importerFile == null)
        {
            throw new Exception("File not found");
        }

        List<ReturnImportDevices> buildings = importerFile!.ImportDevices(args.Path);

        // List<Device> returnList = Transformation(buildings, user);
    }

    private bool FileIsDll(string file)
    {
        return file.EndsWith("dll");
    }

    public bool ImplementsRequiredInterface(Type type)
    {
        return typeof(ImporterInterface).IsAssignableFrom(type) && !type.IsInterface;
    }
}
