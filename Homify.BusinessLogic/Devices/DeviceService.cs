using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Lamps.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.Devices;

public sealed class DeviceService : IDeviceService
{
    private readonly IRepository<Camera> _cameraRepository;
    private readonly IRepository<WindowSensor> _sensorRepository;
    private readonly IRepository<Device> _deviceRepository;
    private readonly IRepository<Lamp> _lampRepository;
    private readonly IRepository<MovementSensor> _movementSensorRepository;
    private readonly ICompanyService _companyService;

    public DeviceService(IRepository<Camera> cameraRepository, IRepository<WindowSensor> sensorRepository, IRepository<Device> deviceRepository, ICompanyService companyService,
        IRepository<Lamp> lampRepository, IRepository<MovementSensor> movementSensorRepository)
    {
        _cameraRepository = cameraRepository;
        _sensorRepository = sensorRepository;
        _deviceRepository = deviceRepository;
        _companyService = companyService;
        _lampRepository = lampRepository;
        _movementSensorRepository = movementSensorRepository;
    }

    public Camera AddCamera(CreateDeviceArgs device, CompanyOwner owner)
    {
        HasCompany(owner);

        if (!string.IsNullOrEmpty(owner.Company.ValidatorType))
        {
            owner.Company.ValidateModel(device.Model ?? string.Empty);
        }

        var camera = new Camera
        {
            Id = Guid.NewGuid().ToString(),
            Name = device.Name,
            Model = device.Model,
            Description = device.Description,
            Photos = device.Photos,
            PpalPicture = device.PpalPicture,
            IsExterior = device.IsExterior,
            IsInterior = device.IsInterior,
            PeopleDetection = device.PeopleDetection,
            MovementDetection = device.MovementDetection,
            Company = owner.Company,
            CompanyId = owner.Company.Id,
        };

        _cameraRepository.Add(camera);
        return camera;
    }

    public WindowSensor AddWindowSensor(CreateDeviceArgs device, CompanyOwner user)
    {
        var owner = (CompanyOwner)user;
        HasCompany(owner);

        if (!string.IsNullOrEmpty(owner.Company.ValidatorType))
        {
            owner.Company.ValidateModel(device.Model ?? string.Empty);
        }

        var sensor = new WindowSensor
        {
            Id = Guid.NewGuid().ToString(),
            Name = device.Name,
            Model = device.Model,
            Description = device.Description,
            Photos = device.Photos,
            PpalPicture = device.PpalPicture,
            Company = owner.Company,
            CompanyId = owner.Company.Id
        };

        _sensorRepository.Add(sensor);
        return sensor;
    }

    public MovementSensor AddMovementSensor(CreateDeviceArgs device, CompanyOwner user)
    {
        var owner = (CompanyOwner)user;
        HasCompany(owner);

        if (!string.IsNullOrEmpty(owner.Company.ValidatorType))
        {
            owner.Company.ValidateModel(device.Model ?? string.Empty);
        }

        var sensor = new MovementSensor
        {
            Id = Guid.NewGuid().ToString(),
            Name = device.Name,
            Model = device.Model,
            Description = device.Description,
            Photos = device.Photos,
            PpalPicture = device.PpalPicture,
            Company = owner.Company,
            CompanyId = owner.Company.Id
        };

        _movementSensorRepository.Add(sensor);
        return sensor;
    }

    public Device GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Device ID cannot be null or empty");
        }

        var device = _deviceRepository.Get(d => d.Id == id);
        if (device == null)
        {
            throw new NotFoundException($"Device with ID '{id}' not found");
        }

        return device;
    }

    private void HasCompany(CompanyOwner? owner)
    {
        var company = _companyService.GetByOwner(owner.Id);
        if (company == null)
        {
            throw new NotFoundException("The user does not have a company");
        }
    }

    public List<Device> GetAll(string? name, string? model, string? company, string? type)
    {
        var devicesQuery = _deviceRepository.GetAll();
        if (!string.IsNullOrEmpty(name))
        {
            devicesQuery = devicesQuery.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(model))
        {
            devicesQuery = devicesQuery.Where(d => d.Model.Contains(model, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(company))
        {
            devicesQuery = devicesQuery.Where(d => d.Company.Name.Contains(company, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(type))
        {
            devicesQuery = devicesQuery.Where(d => d.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return devicesQuery.ToList();
    }

    public List<string> SearchSupportedDevices()
    {
        var list = new List<string>()
        {
            Constants.SENSOR,
            Constants.MOVEMENTSENSOR,
            Constants.LAMP,
            Constants.CAMERA
        };
        return list;
    }

    public Lamp AddLamp(CreateDeviceArgs device, CompanyOwner? user)
    {
        var owner = (CompanyOwner)user;
        HasCompany(owner);

        if (!string.IsNullOrEmpty(owner.Company.ValidatorType))
        {
            owner.Company.ValidateModel(device.Model ?? string.Empty);
        }

        var lamp = new Lamp()
        {
            Id = Guid.NewGuid().ToString(),
            Name = device.Name,
            Model = device.Model,
            Description = device.Description,
            Company = owner.Company,
            CompanyId = owner.Company.Id,
            Photos = device.Photos ?? [],
        };

        _lampRepository.Add(lamp);
        return lamp;
    }
}
