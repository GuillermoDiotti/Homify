using System.Linq.Expressions;
using FluentAssertions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeDeviceServiceTest
{
    private Mock<IRepository<HomeDevice>>? _homeDeviceRepositoryMock;
    private HomeDeviceService? _homeDeviceService;
    private Mock<INotificationService>? _notificationServiceMock;

    [TestInitialize]
    public void Setup()
    {
        _homeDeviceRepositoryMock = new Mock<IRepository<HomeDevice>>();
        _notificationServiceMock = new Mock<INotificationService>();
        _homeDeviceService = new HomeDeviceService(_homeDeviceRepositoryMock.Object, _notificationServiceMock.Object);
    }

    [TestMethod]
    public void AddHomeDevice_ShouldThrowNotFoundException_WhenHomeIsNull()
    {
        Assert.ThrowsException<NotFoundException>(() => _homeDeviceService.Add(null, new Device()));
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

        var result = _homeDeviceService.Add(home, device);

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

        var result = _homeDeviceService.GetByHardwareId(hardwareId);

        Assert.IsNotNull(result);
        Assert.AreEqual(hardwareId, result.HardwareId);
    }

    [TestMethod]
    public void GetHomeDeviceByHardwareId_WhenHardwareIdDoesNotExist_ShouldReturnNull()
    {
        var hardwareId = "hardware1";
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Throws(new NotFoundException("HomeDevice not found"));

        var result = _homeDeviceService.GetByHardwareId(hardwareId);

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
                Members = [new HomeUser { UserId = user.Id }]
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
                Members = [new HomeUser { UserId = user.Id }]
            }
        };

        var activatedDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = homeDevice.Home
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

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
                Members = [new HomeUser { UserId = "anotherUserId" }]
            }
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(homeDevice);

        Assert.ThrowsException<InvalidOperationException>(() => _homeDeviceService.Activate(hardwareId, user));
        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
    }

    [TestMethod]
    public void Deactivate_WithValidHardwareId_ShouldDeactivateDeviceAndUpdateRepository()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = true,
            HardwareId = hardwareId,
            Home = new Home
            {
                OwnerId = user.Id,
                Members = [new HomeUser { UserId = user.Id }]
            }
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(homeDevice);
        _homeDeviceRepositoryMock.Setup(repo => repo.Update(It.IsAny<HomeDevice>()));

        var result = _homeDeviceService.Deactivate(hardwareId, user);

        Assert.IsNotNull(result);
        Assert.IsFalse(result.IsActive);
        Assert.AreEqual(homeDevice.Id, result.Id);

        _homeDeviceRepositoryMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
        _homeDeviceRepositoryMock.Verify(repo => repo.Update(homeDevice), Times.Once, "The repository update method should be called once.");
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateName_WhenHomeDeviceNotFound_ThrowsException()
    {
        var user = new User();
        _homeDeviceService.Rename("NewName", null, user);
    }

    [TestMethod]
    public void UpdateName_WhenInfoValid_UpdatesName()
    {
        var user = new User() { Id = "123" };
        var homeuser = new HomeUser() { UserId = user.Id, HomeId = "idHome", Permissions = [new HomePermission() { Value = PermissionsGenerator.MemberCanChangeNameDevices }] };
        var home = new Home() { Id = "idHome", Members = [homeuser] };
        var homeDevice = new HomeDevice() { Id = "idHomeDevice", DeviceId = "idDevice", HomeId = "idHome", Home = home, HardwareId = "hardwareId", CustomName = "oldName" };
        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);
        var response = _homeDeviceService.Rename("NewName", "idHomeDevice", user);

        response.Id.Should().Be("idHomeDevice");
        response.CustomName.Should().Be("NewName");
    }

    [TestMethod]
    public void LampOn_WhenIsOk_ShouldTurnOnLampAndReturnHomeDevice()
    {
        var hardwareId = "test-hardware-id";
        var device = new Device { Type = Constants.LAMP };
        var homeDevice = new HomeDevice { HardwareId = hardwareId, IsOn = false, Device = device };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.LampOn(hardwareId);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsOn);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void LampOn_WhenDeviceIsNotLamp_ShouldThrowException()
    {
        var hardwareId = "test-hardware-id";
        var device = new Device { Type = Constants.SENSOR };
        var homeDevice = new HomeDevice { HardwareId = hardwareId, IsOn = false, Device = device };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.LampOn(hardwareId);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void LampOff_WhenDeviceIsNotLamp_ShouldThrowException()
    {
        var hardwareId = "test-hardware-id";
        var device = new Device { Type = Constants.SENSOR };
        var homeDevice = new HomeDevice { HardwareId = hardwareId, IsOn = false, Device = device };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.LampOff(hardwareId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void LampOff_WhenDeviceIsNull_ShouldThrowException()
    {
        var hardwareId = "test-hardware-id";

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns((HomeDevice)null);

        var result = _homeDeviceService.LampOff(hardwareId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void LampOn_WhenDeviceIsNull_ShouldThrowException()
    {
        var hardwareId = "test-hardware-id";

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns((HomeDevice)null);

        var result = _homeDeviceService.LampOn(hardwareId);
    }

    [TestMethod]
    public void LampOff_WhenIsOk_ShouldTurnOffLampAndReturnHomeDevice()
    {
        var hardwareId = "test-hardware-id";
        var device = new Device { Type = Constants.LAMP };
        var homeDevice = new HomeDevice { HardwareId = hardwareId, IsOn = false, Device = device };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.LampOff(hardwareId);

        Assert.IsNotNull(result);
        Assert.IsFalse(result.IsOn);
    }

    [TestMethod]
    public void OpenWindow_WithValidSensor_ShouldOpenWindow()
    {
        var hardwareId = "12345";
        var sensorDevice = new Device { Type = Constants.SENSOR };
        var homeDevice = new HomeDevice
        {
            HardwareId = hardwareId,
            Device = sensorDevice,
            IsOn = false
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.OpenWindow(hardwareId);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsOn);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void OpenWindow_WithInvalidDevice_ShouldOpenWindow()
    {
        var hardwareId = "12345";
        var sensorDevice = new Device { Type = Constants.LAMP };
        var homeDevice = new HomeDevice
        {
            HardwareId = hardwareId,
            Device = sensorDevice,
            IsOn = false
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.OpenWindow(hardwareId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void OpenWindow_WithNullDevice_ShouldOpenWindow()
    {
        var hardwareId = "12345";

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns((HomeDevice)null);

        var result = _homeDeviceService.OpenWindow(hardwareId);
    }

    [TestMethod]
    public void CloseWindow_WithValidSensor_ShouldCloseWindow()
    {
        var hardwareId = "12345";
        var sensorDevice = new Device { Type = Constants.SENSOR };
        var homeDevice = new HomeDevice
        {
            HardwareId = hardwareId,
            Device = sensorDevice,
            IsOn = false
        };

        _homeDeviceRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns(homeDevice);

        var result = _homeDeviceService.CloseWindow(hardwareId);

        Assert.IsNotNull(result);
        Assert.IsFalse(result.IsOn);
    }

    [TestMethod]
    public void GetAAll_ByHomeDeviceId()
    {
        var hardwareId = "Device123";
        var user = new User { Id = "testUserId" };
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            IsActive = false,
            HardwareId = hardwareId,
            Home = new Home { OwnerId = user.Id, Members = [new HomeUser { UserId = user.Id }] }
        };

        _homeDeviceRepositoryMock.Setup(d => d.GetAll(It.IsAny<Expression<Func<HomeDevice, bool>>>()))
            .Returns([homeDevice]);

        _homeDeviceService.GetByHomeId("testUserId");

        _homeDeviceRepositoryMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<HomeDevice, bool>>>()), Times.Once);
    }

    [TestMethod]
    public void Rename_WhenUserIsOwner_UpdatesDeviceName()
    {
        var userId = "user-123";
        var home = new Home { Id = "home-123", OwnerId = userId };
        var device = new HomeDevice { Id = "device-123", HardwareId = "hw-123", Home = home };
        var user = new User { Id = userId };

        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(device);
        _homeDeviceRepositoryMock.Setup(r => r.Update(It.IsAny<HomeDevice>())).Verifiable();

        var result = _homeDeviceService.Rename("NewName", "device-123", user);

        Assert.AreEqual("NewName", result.CustomName);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Rename_WhenUserNotFoundInHome_ThrowsNotFoundException()
    {
        var userId = "user-123";
        var home = new Home { Id = "home-123", OwnerId = "owner-123", Members =  new List<HomeUser>() };
        var device = new HomeDevice { Id = "device-123", HardwareId = "hw-123", Home = home };
        var user = new User { Id = userId };

        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(device);

        _homeDeviceService.Rename("NewName", "device-123", user);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Rename_WhenUserHasNoPermission_ThrowsInvalidOperationException()
    {
        var userId = "user-123";
        var home = new Home
        {
            Id = "home-123",
            OwnerId = "owner-123",
            Members = new List<HomeUser>
            {
                new HomeUser() { UserId = userId, Permissions = new List<HomePermission>() }
            }
        };
        var device = new HomeDevice { Id = "device-123", HardwareId = "hw-123", Home = home };
        var user = new User { Id = userId };

        _homeDeviceRepositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomeDevice, bool>>>())).Returns(device);

        _homeDeviceService.Rename("NewName", "device-123", user);
    }
}
