using System.Linq.Expressions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class DeviceServiceTest
{
    private Mock<IRepository<Camera>>? _cameraRepositoryMock;
    private Mock<IRepository<Sensor>>? _sensorRepositoryMock;
    private Mock<IRepository<Device>>? _deviceRepositoryMock;
    private DeviceService? _deviceService;
    private Mock<ICompanyService>? _companyServiceMock;

    [TestInitialize]
    public void Setup()
    {
        _cameraRepositoryMock = new Mock<IRepository<Camera>>();
        _sensorRepositoryMock = new Mock<IRepository<Sensor>>();
        _deviceRepositoryMock = new Mock<IRepository<Device>>();
        _companyServiceMock = new Mock<ICompanyService>();
        _deviceService = new DeviceService(_cameraRepositoryMock.Object, _sensorRepositoryMock.Object, _deviceRepositoryMock.Object, _companyServiceMock.Object);
    }

    [TestMethod]
    public void AddCamera_ShouldAddCameraToRepository()
    {
        var createDeviceArgs = new CreateDeviceArgs(
            "Test Camera",
            "Model X",
            "Test Description",
            [
                "photo1.jpg",
                "photo2.jpg"
            ],
            "photo1.jpg",
            true,
            false);

        var user = new CompanyOwner
        {
            Id = "1",
            Name = "John",
            Email = "john@example.com",
            Company = new Company
            {
                Id = "company1",
                Name = "Test Company"
            }
        };

        _cameraRepositoryMock.Setup(r => r.Add(It.IsAny<Camera>())).Verifiable();

        _companyServiceMock.Setup(r => r.GetByUserId("1")).Returns(user.Company);

        _cameraRepositoryMock.Setup(r => r.Add(It.IsAny<Camera>())).Verifiable();

        var result = _deviceService.AddCamera(createDeviceArgs, user);

        Assert.IsNotNull(result);
        Assert.AreEqual(createDeviceArgs.Name, result.Name);
        Assert.AreEqual(createDeviceArgs.Model, result.Model);
        Assert.AreEqual(createDeviceArgs.Description, result.Description);
        Assert.AreEqual(createDeviceArgs.Photos, result.Photos);
        Assert.AreEqual(createDeviceArgs.PpalPicture, result.PpalPicture);
        Assert.AreEqual(createDeviceArgs.IsExterior, result.IsExterior);
        Assert.AreEqual(createDeviceArgs.IsInterior, result.IsInterior);
        Assert.AreEqual(user.Company, result.Company);
    }

    [TestMethod]
    public void AddSensor_ShouldAddSensor_WhenValidArguments()
    {
        // Arrange
        var deviceArgs = new CreateDeviceArgs(
            "Test Sensor",
            "Model X",
            "Test Description",
            [
                "photo1.jpg",
                "photo2.jpg"
            ],
            "mainphoto.jpg",
            true,
            false);

        var company = new Company { Id = "companyId", Name = "Test Company" };
        var user = new CompanyOwner { Company = company, Id = "1" };

        _cameraRepositoryMock.Setup(r => r.Add(It.IsAny<Camera>())).Verifiable();

        _companyServiceMock.Setup(r => r.GetByUserId("1")).Returns(user.Company);

        var result = _deviceService.AddSensor(deviceArgs, user);

        _sensorRepositoryMock.Verify(r => r.Add(It.IsAny<Sensor>()), Times.Once);
        Assert.IsNotNull(result);
        Assert.AreEqual(deviceArgs.Name, result.Name);
        Assert.AreEqual(deviceArgs.Model, result.Model);
        Assert.AreEqual(deviceArgs.Description, result.Description);
        Assert.AreEqual(deviceArgs.Photos, result.Photos);
        Assert.AreEqual(deviceArgs.PpalPicture, result.PpalPicture);
        Assert.AreEqual(company, result.Company);
        Assert.AreEqual(company.Id, result.CompanyId);
    }

    [TestMethod]
    public void GetById_WhenDeviceExists_ShouldReturnDevice()
    {
        var deviceId = "test-device-id";
        var device = new Device { Id = deviceId, Name = "Test Device" };
        _deviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Device, bool>>>()))
            .Returns(device);

        var result = _deviceService.GetById(deviceId);

        Assert.IsNotNull(result);
        Assert.AreEqual(deviceId, result.Id);
        Assert.AreEqual("Test Device", result.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void GetById_WhenDeviceNotFound_ShouldThrowKeyNotFoundException()
    {
        var deviceId = "non-existent-device-id";
        _deviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Device, bool>>>()))
            .Returns((Device)null);

        _deviceService.GetById(deviceId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetById_WhenDeviceIdIsNullOrEmpty_ShouldThrowArgumentException()
    {
        var deviceId = string.Empty;
        _deviceService.GetById(deviceId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AddCamera_WhenCompanyIsNull_ShouldThrowNotFoundException()
    {
        var createDeviceArgs = new CreateDeviceArgs(
            "Test Camera",
            "Model X",
            "Test Description",
            [
                "photo1.jpg",
                "photo2.jpg"
            ],
            "photo1.jpg",
            true,
            false);

        var user = new CompanyOwner
        {
            Id = "1",
            Name = "John",
            Email = "john@example.com",
            Company = null
        };

        _deviceService.AddCamera(createDeviceArgs, user);
    }

    [TestMethod]
    public void SearchDevices_WithValidFilters_ReturnsFilteredDevices()
    {
        var deviceList = new List<Device>
            {
                new Device
                {
                    Id = "1",
                    Name = "Camera 1",
                    Model = "Model A",
                    Company = new Company
                    {
                        Id = "1",
                        Name = "Company A"
                    },
                },
                new Device
                {
                    Id = "2",
                    Name = "Sensor 1",
                    Model = "Model B",
                    Company = new Company
                    {
                        Id = "2",
                        Name = "Company B"
                    },
                },
                new Device
                {
                    Id = "3",
                    Name = "Camera 2",
                    Model = "Model C",
                    Company = new Company
                    {
                        Id = "1",
                        Name = "Company A"
                    },
                }
            };

        _deviceRepositoryMock
            .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Device, bool>>>()))
            .Returns(deviceList);

        var searchArgs = new SearchDevicesArgs
        {
            DeviceName = "Camera",
            Model = "Model A",
            Company = "Company A",
            Limit = 10,
            Offset = 0
        };
        var result = _deviceService.SearchDevices(searchArgs);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Camera 1", result.First().Name);
        Assert.AreEqual("Model A", result.First().Model);
    }

    [TestMethod]
    public void SearchSupportedDevices_ReturnsUniqueDeviceTypes()
    {
        var deviceList = new List<Device>
        {
            new Device
            {
                Id = "1",
                Name = "Camera",
                Model = "Model A",
                Type = "Camera"
            },
            new Device
            {
                Id = "2",
                Name = "Sensor",
                Model = "Model B",
                Type = "Sensor"
            },
            new Device
            {
                Id = "3",
                Name = "Camera 2",
                Model = "Model C",
                Type = "Camera"
            },
            new Device
            {
                Id = "4",
                Name = "Thermostat",
                Model = "Model D",
                Type = "Thermostat"
            }
        };

        _deviceRepositoryMock
            .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Device, bool>>>()))
            .Returns(deviceList);

        var result = _deviceService.SearchSupportedDevices();

        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEqual(new List<string> { "Camera", "Sensor", "Thermostat" }, result);
    }
}
