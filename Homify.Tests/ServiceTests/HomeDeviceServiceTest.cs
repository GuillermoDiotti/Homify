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
}
