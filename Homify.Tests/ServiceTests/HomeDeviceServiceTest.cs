using System.Linq.Expressions;
using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;
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
    public void Activate_WithValidHardwareId_ShouldActivateDeviceAndUpdateRepository()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = user.Id,
                Members = new List<HomeUser> { new HomeUser { UserId = user.Id } }
            }
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(homeDevice);
        _homeDeviceRepositoryMock.Setup(repo => repo.Update(It.IsAny<HomeDevice>()));

        var result = _homeDeviceService.Activate(hardwareId, user);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsActive, "The HomeDevice should be activated (IsActive = true).");
        Assert.AreEqual(homeDevice.Id, result.Id);

        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
        _homeDeviceRepositoryMock.Verify(repo => repo.Update(homeDevice), Times.Once, "The repository update method should be called once.");
    }

    [TestMethod]
    public void Activate_WithValidHardwareId_ShouldReturnActivatedDevice()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = user.Id,
                Members = new List<HomeUser> { new HomeUser { UserId = user.Id } }
            }
        };

        var activatedDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = homeDevice.Home
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(homeDevice);

        var result = _homeDeviceService.Activate(hardwareId, user);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsActive);
        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
        _homeDeviceRepositoryMock.Verify(repo => repo.Update(It.IsAny<HomeDevice>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Activate_WhenHomeDeviceNotFound_ShouldThrowNotFoundException()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns<HomeDevice>(null);

        _homeDeviceService.Activate(hardwareId, user);
    }

    [TestMethod]
    public void Activate_WhenHomeDeviceDoesNotExist_ShouldThrowNotFoundException()
    {
        var hardwareId = "non-existent-id";
        var user = new User { Id = "testUserId" };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns((HomeDevice)null);

        Assert.ThrowsException<NotFoundException>(() => _homeDeviceService.Activate(hardwareId, user));
        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
    }

    [TestMethod]
    public void Activate_WhenUserIsNotMemberOrOwner_ShouldThrowInvalidOperationException()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = "anotherUserId",
                Members = new List<HomeUser> { new HomeUser { UserId = "anotherUserId" } }
            }
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(homeDevice);

        Assert.ThrowsException<InvalidOperationException>(() => _homeDeviceService.Activate(hardwareId, user));
        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateName_WhenHomeDeviceNotFound_ThrowsException()
    {
        _homeDeviceService.UpdateHomeDevice("NewName", null);
    }

    [TestMethod]
    public void UpdateName_WhenInfoValid_UpdatesName()
    {
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(new HomeDevice() { Id = "idDevice" });
        var response = _homeDeviceService.UpdateHomeDevice("NewName", "idDevice");

        response.Id.Should().Be("idDevice");
        response.CustomName.Should().Be("NewName");
    }
}
