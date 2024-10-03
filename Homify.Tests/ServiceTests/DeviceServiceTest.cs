using System.Linq.Expressions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Users.Entities;
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
            new List<string> { "photo1.jpg", "photo2.jpg" },
            "photo1.jpg",
            true,
            false
        );

        var user = new CompanyOwner
        {
            Id = "1",
            Name = "John",
            Email = "john@example.com",
            Company = new Company { Id = "company1", Name = "Test Company" }
        };

        _cameraRepositoryMock.Setup(r => r.Add(It.IsAny<Camera>())).Verifiable();

        var result = _deviceService.AddCamera(createDeviceArgs, user);

        _cameraRepositoryMock.Verify(r => r.Add(It.Is<Camera>(c =>
            c.Name == createDeviceArgs.Name &&
            c.Model == createDeviceArgs.Model &&
            c.Description == createDeviceArgs.Description &&
            c.Photos == createDeviceArgs.Photos &&
            c.PpalPicture == createDeviceArgs.PpalPicture &&
            c.IsExterior == createDeviceArgs.IsExterior &&
            c.IsInterior == createDeviceArgs.IsInterior &&
            c.Company == user.Company)), Times.Once);

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
            new List<string> { "photo1.jpg", "photo2.jpg" },
            "mainphoto.jpg",
            true,
            false
        );

        var company = new Company { Id = "companyId", Name = "Test Company" };
        var user = new CompanyOwner { Company = company };

        // Act
        var result = _deviceService.AddSensor(deviceArgs, user);

        // Assert
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

        var device = _deviceService.GetById(deviceId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetById_WhenDeviceIdIsNullOrEmpty_ShouldThrowArgumentException()
    {
        var deviceId = string.Empty;
        var device = _deviceService.GetById(deviceId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AddCamera_WhenCompanyIsNull_ShouldThrowNotFoundException()
    {
        var createDeviceArgs = new CreateDeviceArgs(
            "Test Camera",
            "Model X",
            "Test Description",
            new List<string> { "photo1.jpg", "photo2.jpg" },
            "photo1.jpg",
            true,
            false
        );

        var user = new CompanyOwner
        {
            Id = "1",
            Name = "John",
            Email = "john@example.com",
            Company = null
        };

        var device = _deviceService.AddCamera(createDeviceArgs, user);
    }
}
