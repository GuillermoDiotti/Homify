using System.Reflection;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Importers.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Importer.Abstractions;
using Homify.Importer.Abstractions.Models;
using ModeloValidador.Abstracciones;

namespace Homify.BusinessLogic.Importers;

public sealed class ImporterService : IImporterService
{
    private readonly IDeviceService? _deviceService;
    private readonly ICompanyOwnerService _companyOwnerService;

    public ImporterService(IDeviceService deviceService, ICompanyOwnerService companyOwnerService)
    {
        _deviceService = deviceService;
        _companyOwnerService = companyOwnerService;
    }

    public List<IModeloValidador> GetAllValidators()
    {
        var rutaDll = "./Validators";
        var filePaths = Directory.GetFiles(rutaDll);

        var availableImporters = new List<IModeloValidador>();

        foreach (var file in filePaths)
        {
            if (FileIsDll(file))
            {
                var dllFile = new FileInfo(file);
                var myAssembly = Assembly.LoadFile(dllFile.FullName);

                foreach (Type type in myAssembly.GetTypes())
                {
                    if (ImplementsRequiredInterface<IModeloValidador>(type))
                    {
                        var instance = (IModeloValidador)Activator.CreateInstance(type);
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

    public List<IImporter> GetAll()
    {
        var importersPath = "./Importers";
        var filePaths = Directory.GetFiles(importersPath);

        var availableImporters = new List<IImporter>();

        foreach (var file in filePaths)
        {
            if (FileIsDll(file))
            {
                var dllFile = new FileInfo(file);
                var myAssembly = Assembly.LoadFile(dllFile.FullName);

                foreach (Type type in myAssembly.GetTypes())
                {
                    if (ImplementsRequiredInterface<IImporter>(type))
                    {
                        var instance = (IImporter)Activator.CreateInstance(type);
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
        var owner = _companyOwnerService.GetById(user.Id);

        if (owner == null)
        {
            throw new System.InvalidOperationException("User is not a company owner");
        }

        if (owner.Company == null)
        {
            throw new System.InvalidOperationException("Owner must have a company to import devices");
        }

        IImporter? importerFile = GetAll()
            .FirstOrDefault(i => i.GetName().Equals(args.Importer, StringComparison.OrdinalIgnoreCase));

        if (importerFile == null)
        {
            throw new NotFoundException("File not found");
        }

        List<ReturnImportDevices> devices = importerFile!.ImportDevices(args.Path);

        Transformation(devices, user);
    }

    public void Transformation(List<ReturnImportDevices> devices, User user)
    {
        foreach (var device in devices)
        {
            var newDevice = new CreateDeviceArgs
            {
                Name = device.Name,
                Model = device.Model,
                Id = device.Id,
                Type = device.Type,
                PeopleDetection = device.PersonDetection,
                MovementDetection = device.MovementDetection,
                Description = "importado",
                IsExterior = false,
                IsInterior = false
            };
            var returnList = new List<string>();
            foreach (var photo in device.Photos)
            {
                if (photo.IsPrincipal == true)
                {
                    newDevice.PpalPicture = photo.Path;
                }

                returnList.Add(photo.Path);
            }

            newDevice.Photos = returnList;
            var companyOwner = _companyOwnerService.GetById(user.Id);

            AddImportedDeviceByType(newDevice, companyOwner);
        }
    }

    public void AddImportedDeviceByType(CreateDeviceArgs device, CompanyOwner? user)
    {
        if (device.Type == "camera")
        {
            _deviceService.AddCamera(device, user);
        }
        else if (device.Type == "sensor-movement")
        {
            _deviceService.AddMovementSensor(device, user);
        }
        else if (device.Type == "sensor-open-close")
        {
            _deviceService.AddWindowSensor(device, user);
        }
    }

    public List<string> TransformPhotos(List<ReturnPhotos> photos)
    {
        var returnList = new List<string>();
        foreach (var photo in photos)
        {
            returnList.Add(photo.Path);
        }

        return returnList;
    }

    private bool FileIsDll(string file)
    {
        return file.EndsWith("dll");
    }

    public bool ImplementsRequiredInterface<T>(Type type)
    {
        return typeof(T).IsAssignableFrom(type) && !type.IsInterface;
    }
}
