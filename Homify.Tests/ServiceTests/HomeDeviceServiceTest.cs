using System.Linq.Expressions;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.DataAccess.Repositories;
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
        var home = new Home { Id = homeId };
        var device = new Device { Id = deviceId };

        // Act
        var result = _homeDeviceService.AddHomeDevice(home, device);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(homeId, result.HomeId);
        Assert.AreEqual(deviceId, result.DeviceId);
    }

    [TestMethod]
    public void GetHomeDeviceByHardwareId_WhenHardwareIdExists_ShouldReturnHomeDevice()
    {
        var hardwareId = "hardware1";
        var expectedHomeDevice = new HomeDevice { HardwareId = hardwareId };
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(expectedHomeDevice);

        var result = _homeDeviceService.GetHomeDeviceByHardwareId(hardwareId);

        Assert.IsNotNull(result);
        Assert.AreEqual(hardwareId, result.HardwareId);
    }
}
