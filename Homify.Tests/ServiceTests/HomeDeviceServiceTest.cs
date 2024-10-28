using System.Linq.Expressions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeDeviceServiceTest
{
    private Mock<IRepository<HomeDevice>>? _homeDeviceRepositoryMock;
    private HomeDeviceService? _homeDeviceService;

    [TestInitialize]
    public void Setup()
    {
        _homeDeviceRepositoryMock = new Mock<IRepository<HomeDevice>>();
        _homeDeviceService = new HomeDeviceService(_homeDeviceRepositoryMock.Object);
    }

    [TestMethod]
    public void AddHomeDevice_ShouldAddDeviceToHome_WhenHomeExists()
    {
        // Arrange
        var homeId = "home1";
        var deviceId = "device1";
        var home = new Home
        {
            Id = homeId
        };
        var device = new Device
        {
            Id = deviceId
        };

        var result = _homeDeviceService.AddHomeDevice(home, device);

        Assert.IsNotNull(result);
        Assert.AreEqual(homeId, result.HomeId);
        Assert.AreEqual(deviceId, result.DeviceId);
    }

    [TestMethod]
    public void GetHomeDeviceByHardwareId_WhenHardwareIdExists_ShouldReturnHomeDevice()
    {
        var hardwareId = "hardware1";
        var expectedHomeDevice = new HomeDevice
        {
            HardwareId = hardwareId
        };
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(expectedHomeDevice);

        var result = _homeDeviceService.GetHomeDeviceByHardwareId(hardwareId);

        Assert.IsNotNull(result);
        Assert.AreEqual(hardwareId, result.HardwareId);
    }

    [TestMethod]
    public void GetHomeDeviceByHardwareId_WhenHardwareIdDoesNotExist_ShouldReturnNull()
    {
        var hardwareId = "hardware1";
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Throws(new NotFoundException("HomeDevice not found"));

        var result = _homeDeviceService.GetHomeDeviceByHardwareId(hardwareId);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void Activate_ShouldActivateDeviceAndUpdateRepository()
    {
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Update(It.IsAny<HomeDevice>()));
        var result = _homeDeviceService.Activate(homeDevice);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsActive, "The HomeDevice should be activated (IsActive = true).");
        Assert.AreEqual(homeDevice.Id, result.Id);

        _homeDeviceRepositoryMock.Verify(repo => repo.Update(homeDevice), Times.Once, "The repository update method should be called once.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void UpdateName_WhenIdHomeDeviceIsNull_ThrowsException()
    {
        _homeDeviceService.UpdateHomeDevice("NewName", null);
    }
}
