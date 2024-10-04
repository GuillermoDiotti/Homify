using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Notifications;
using Homify.WebApi.Controllers.Notifications.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class NotificationControllerTest
{
    private readonly Mock<INotificationService> _notificationService;
    private readonly Mock<IHomeDeviceService> _homeDeviceService;
    private readonly NotificationController _controller;

    public NotificationControllerTest()
    {
        _notificationService = new Mock<INotificationService>(MockBehavior.Strict);
        _homeDeviceService = new Mock<IHomeDeviceService>(MockBehavior.Strict);
        _controller = new NotificationController(_notificationService.Object, _homeDeviceService.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateNotification_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        _controller.PersonDetectedNotification(null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void CreateNotification_WhenDeviceIsNull_ShouldThrowNotFoundException()
    {
        var req = new CreateNotificationRequest()
        {
            DeviceId = "1",
            PersonDetectedId = Guid.NewGuid().ToString(),
        };

        _homeDeviceService.Setup(d => d.GetHomeDeviceByHardwareId(It.IsAny<string>())).Returns((HomeDevice?)null);

        _controller.PersonDetectedNotification(req);
    }

    [TestMethod]
    public void CreateNotification_WhenDataIsOk_ShouldCreateNotification()
    {
        var req = new CreateNotificationRequest()
        {
            DeviceId = "1",
            PersonDetectedId = Guid.NewGuid().ToString(),
        };
        var device = new HomeDevice();
        var homeDevice = new HomeDevice();
        var expected = new Notification()
        {
            Event = req.PersonDetectedId,
            Device = homeDevice,
            IsRead = false,
            Id = Guid.NewGuid().ToString()
        };
        _homeDeviceService.Setup(d => d.GetHomeDeviceByHardwareId(It.IsAny<string>())).Returns(device);
        _notificationService.Setup(n => n.AddPersonDetectedNotification(It.IsAny<CreateNotificationArgs>())).Returns(expected);

        var result = _controller.PersonDetectedNotification(req);

        result.Id.Should().NotBeNull();
        result.Id.Should().Be(expected.Id);
    }

    [TestMethod]
    public void GetNotifications_ShouldReturnUserNotifications()
    {
        var expected = new List<Notification>();
        _notificationService.Setup(n => n.GetAllByUserId(It.IsAny<string>())).Returns(expected);
        var result = _controller.ObtainNotifications("pablito lescano");

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ReadNotification_ShouldReadNotification()
    {
        var expected = new Notification()
        {
            Id = "a1",
            IsRead = true,
        };
        _notificationService.Setup(n => n.ReadNotificationById(It.IsAny<string>())).Returns(expected);
        var result = _controller.UpdateNotification("lucas sugo");

        result.Should().NotBeNull();
        result.Id.Should().BeEquivalentTo(expected.Id);
        result.IsRead.Should().BeTrue();
    }

    [TestMethod]
    public void NotificationBasicInfo_ShouldMapCorrectlyFromNotificationEntity()
    {
        var device = new Device
        {
            Id = "device123",
        };
        var homeDevice = new HomeDevice() { Device = device, };

        var notification = new Notification
        {
            Id = "notif123",
            Event = "Test Event",
            Device = homeDevice,
            Date = DateTimeOffset.UtcNow,
            IsRead = false
        };

        var notificationBasicInfo = new NotificationBasicInfo(notification);

        notificationBasicInfo.Id.Should().Be(notification.Id);
        notificationBasicInfo.Event.Should().Be(notification.Event);
        notificationBasicInfo.DeviceId.Should().Be(notification.Device.Id);
        notificationBasicInfo.IsRead.Should().Be(notification.IsRead);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void WindowMovementNotification_ShouldThrowNullRequestException_WhenRequestIsNull()
    {
        _controller.WindowMovementNotification(null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void WindowMovementNotification_ShouldThrowNotFoundException_WhenDeviceIsNotFound()
    {
        var request = new CreateNotificationRequest
        {
            HardwareId = "InvalidHardwareId",
            PersonDetectedId = "Person1"
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns((HomeDevice)null);

        _controller.WindowMovementNotification(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void WindowMovementNotification_ShouldThrowInvalidOperationException_WhenDeviceIsNotSensor()
    {
        var request = new CreateNotificationRequest
        {
            HardwareId = "ValidHardwareId",
            PersonDetectedId = "Person1"
        };

        var homeDevice = new HomeDevice { Id = "Device123", Device = new Device { Type = "Camera" } };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _controller.WindowMovementNotification(request);
    }

    [TestMethod]
    public void WindowMovementNotification_ShouldReturnNotification_WhenRequestIsValid()
    {
        var request = new CreateNotificationRequest
        {
            HardwareId = "ValidHardwareId",
            PersonDetectedId = "Person1",
        };

        var homeDevice = new HomeDevice { Id = "Device123", Device = new Device { Type = Constants.SENSOR }, HardwareId = "333" };

        var notification = new Notification
        {
            Id = "Notification123",
            Event = "Window state switch detected",
            IsRead = false,
            HomeDeviceId = homeDevice.Id,
            HomeUserId = "User123",
            Date = DateTimeOffset.Now,
            Device = homeDevice,
            DetectedUserId = null,
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _notificationService.Setup(s => s.AddWindowNotification(It.IsAny<CreateNotificationArgs>()))
            .Returns(notification);

        var result = _controller.WindowMovementNotification(request);

        Assert.IsNotNull(result);
        Assert.AreEqual("Notification123", result.Id);
        Assert.AreEqual("Window state switch detected", result.Event);
        _homeDeviceService.Verify(s => s.GetHomeDeviceByHardwareId(request.HardwareId), Times.Once);
        _notificationService.Verify(s => s.AddWindowNotification(It.IsAny<CreateNotificationArgs>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateMovementDetectionNotification_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.MovementNotification(null);
    }
}
