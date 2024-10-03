using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Devices;

public class DeviceService : IDeviceService
{
    private readonly IRepository<Camera> _cameraRepository;
    private readonly IRepository<Sensor> _sensorRepository;
    private readonly IRepository<Device> _deviceRepository;
    private readonly ICompanyService _companyService;

    public DeviceService(IRepository<Camera> cameraRepository, IRepository<Sensor> sensorRepository, IRepository<Device> deviceRepository, ICompanyService companyService)
    {
        _cameraRepository = cameraRepository;
        _sensorRepository = sensorRepository;
        _deviceRepository = deviceRepository;
        _companyService = companyService;
    }

    public Camera AddCamera(CreateDeviceArgs device, CompanyOwner owner)
    {
        HasCompany(owner);
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
            Company = owner.Company,
            CompanyId = owner.Company.Id,
        };

        _cameraRepository.Add(camera);
        return camera;
    }

    public Sensor AddSensor(CreateDeviceArgs device, CompanyOwner user)
    {
        CompanyOwner owner = (CompanyOwner)user;
        HasCompany(owner);
        var sensor = new Sensor
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
        var company = _companyService.GetByUserId(owner.Id);
        if (company == null)
        {
            throw new NotFoundException("The user does not have a company");
        }
    }
}
