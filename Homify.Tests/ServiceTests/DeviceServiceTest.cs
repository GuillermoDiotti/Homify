using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class DeviceServiceTest
{
    private Mock<IRepository<Camera>>? _cameraRepositoryMock;
    private Mock<IRepository<Sensor>>? _sensorRepositoryMock;
    private Mock<IRepository<Device>>? _deviceRepositoryMock;
    private DeviceService? _deviceService;

    [TestInitialize]
    public void Setup()
    {
        _cameraRepositoryMock = new Mock<IRepository<Camera>>();
        _sensorRepositoryMock = new Mock<IRepository<Sensor>>();
        _deviceRepositoryMock = new Mock<IRepository<Device>>();
        _deviceService = new DeviceService(_cameraRepositoryMock.Object, _sensorRepositoryMock.Object, _deviceRepositoryMock.Object);
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
}
