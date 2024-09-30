using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Devices;

public class DeviceService : IDeviceService
{
    private readonly IRepository<Camera> _cameraRepository;
    private readonly IRepository<Sensor> _sensorRepository;
    private readonly IRepository<Device> _deviceRepository;

    public DeviceService(IRepository<Camera> cameraRepository, IRepository<Sensor> sensorRepository, IRepository<Device> deviceRepository)
    {
        _cameraRepository = cameraRepository;
        _sensorRepository = sensorRepository;
        _deviceRepository = deviceRepository;
    }

    public Camera AddCamera(CreateDeviceArgs device, User user)
    {
        CompanyOwner owner = (CompanyOwner)user;
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

    public Sensor AddSensor(CreateDeviceArgs device, User user)
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
        throw new NotImplementedException();
    }

    private void HasCompany(CompanyOwner owner)
    {
        if (owner.Company == null)
        {
            throw new Exception("The user does not have a company");
        }
    }
}
