using FluentAssertions;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Controllers.Notifications;
using Homify.WebApi.Controllers.Notifications.Models;
using Homify.WebApi.Controllers.Notifications.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

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
    public void PersonDetectedNotification_ShouldReturnNotification_WhenRequestIsValid()
    {
        var request = new CreateNotificationRequest { HardwareId = "validHardwareId", PersonDetectedId = "personId" };
        var homeDevice = new HomeDevice { Id = "Device123", Device = new Device { Type = "CAMERA" }, IsActive = true };
        var notification = new Notification
        {
            Id = "Notification123",
            Event = "Person detected",
            IsRead = false,
            HomeDeviceId = homeDevice.Id,
            HomeUserId = "User123",
            Device = homeDevice,
            Detail = null,
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _notificationService.Setup(s => s.AddPersonDetectedNotification(It.IsAny<CreateNotificationArgs>()))
            .Returns([notification]);

        var result = _controller.PersonDetectedNotification(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Notification123", result[0].Id);
        Assert.AreEqual("Person detected", result[0].Event);
    }

    [TestMethod]
    public void ObtainNotifications_ShouldReturnFilteredNotifications()
    {
        var userId = "testUserId";
        var user = new User { Id = userId };
        var notifications = new List<Notification>
        {
            new Notification { Event = "Event1", IsRead = false, Device = new HomeDevice { Id = "Device1", Device = new Device { Type = "Event1" } }, Date = HomifyDateTime.Parse("10/10/2024") },
            new Notification { Event = "Event2", IsRead = true, Device = new HomeDevice { Id = "Device2", Device = new Device { Type = "Event2" } } }
        };

        _notificationService.Setup(n => n.GetAllByUserId(userId)).Returns(notifications);

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = user;

        var mockController = new NotificationController(_notificationService.Object, _homeDeviceService.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        var result = mockController.ObtainNotifications("event1", "10/10/2024", "false");

        result.Should().NotBeNull();
        result.Count.Should().Be(1);
        result[0].Event.Should().Be("Event1");
        result[0].IsRead.Should().BeFalse();
    }

    [TestMethod]
    public void UpdateNotification_WhenNotificationExists_ShouldReturnUpdatedNotification()
    {
        var userId = "testUserId";
        var user = new User { Id = userId };
        var notificationId = "testNotificationId";
        var notification = new Notification { Id = notificationId, Event = "Event1", IsRead = false };

        _notificationService.Setup(n => n.ReadNotificationById(notificationId, user)).Returns(notification);

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = user;

        var mockController = new NotificationController(_notificationService.Object, _homeDeviceService.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        var result = mockController.UpdateNotification(notificationId);

        result.Should().NotBeNull();
        result.Id.Should().Be(notificationId);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateNotification_WhenNotificationDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var userId = "testUserId";
        var user = new User { Id = userId };
        var notificationId = "nonExistentNotificationId";

        _notificationService.Setup(n => n.ReadNotificationById(notificationId, user)).Returns((Notification)null);

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = user;

        var mockController = new NotificationController(_notificationService.Object, _homeDeviceService.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        mockController.UpdateNotification(notificationId);
    }

    [TestMethod]
    public void NotificationBasicInfo_ShouldMapCorrectlyFromNotificationEntity()
    {
        var device = new Device
        {
            Id = "device123",
        };
        var homeDevice = new HomeDevice()
        {
            Device = device,
        };

        var notification = new Notification
        {
            Id = "notif123",
            Event = "Test Event",
            Device = homeDevice,
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
        var request = new CreateGenericNotificationRequest
        {
            DeviceId = "1",
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns((HomeDevice)null);

        _controller.WindowMovementNotification(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void WindowMovementNotification_ShouldThrowInvalidOperationException_WhenDeviceIsNotSensor()
    {
        var request = new CreateGenericNotificationRequest
        {
            HardwareId = "ValidHardwareId",
        };

        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            Device = new Device
            {
                Type = "Camera"
            }
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _controller.WindowMovementNotification(request);
    }

    [TestMethod]
    public void WindowMovementNotification_ShouldReturnNotification_WhenRequestIsValid()
    {
        var request = new CreateGenericNotificationRequest { HardwareId = "validHardwareId", Action = "action" };
        var homeDevice = new HomeDevice { Id = "Device123", Device = new Device { Type = "SENSOR" }, IsActive = true };
        var notification = new Notification
        {
            Id = "Notification123",
            Event = "Window movement detected",
            IsRead = false,
            HomeDeviceId = homeDevice.Id,
            HomeUserId = "User123",
            Device = homeDevice,
            Detail = null,
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _notificationService.Setup(s => s.AddWindowNotification(It.IsAny<CreateGenericNotificationArgs>()))
            .Returns([notification]);

        var result = _controller.WindowMovementNotification(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Notification123", result[0].Id);
        Assert.AreEqual("Window movement detected", result[0].Event);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateMovementDetectionNotification_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.MovementNotification(null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void CreateMovementDetectionNotification_WhenHardwareIdIsNull_ShouldThrowException()
    {
        var request = new CreateGenericNotificationRequest
        {
            HardwareId = null
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Throws(new NotFoundException("HardwareId not found"));

        _controller.MovementNotification(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void CreateMovementDetectionNotification_WhenHardwareIdIsIncorrect_ShouldThrowException()
    {
        var request = new CreateGenericNotificationRequest
        {
            HardwareId = "hardwareId"
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Throws(new NotFoundException("HardwareId not found"));

        _controller.MovementNotification(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void CreateMovementDetectionNotification_WhenDeviceIsNull_ShouldThrowException()
    {
        var request = new CreateGenericNotificationRequest
        {
            DeviceId = null,
            HardwareId = "hardwareId"
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns((HomeDevice?)null);

        _controller.MovementNotification(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CreateMovementDetectionNotification_WhenDeviceIsSensor_ShouldThrowException()
    {
        var request = new CreateGenericNotificationRequest
        {
            DeviceId = "id",
            HardwareId = "hardwareId"
        };

        var expectedDevice = new Device
        {
            Type = Constants.SENSOR
        };

        var homeDevice = new HomeDevice()
        {
            DeviceId = "id",
            Device = expectedDevice
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _controller.MovementNotification(request);
    }

    [TestMethod]
    public void MovementNotification_ShouldReturnNotification_WhenRequestIsValid()
    {
        var request = new CreateGenericNotificationRequest { HardwareId = "validHardwareId", Action = "action" };
        var homeDevice = new HomeDevice { Id = "Device123", Device = new Device { Type = "CAMERA" }, IsActive = true };
        var notification = new Notification
        {
            Id = "Notification123",
            Event = "Movement detected",
            IsRead = false,
            HomeDeviceId = homeDevice.Id,
            HomeUserId = "User123",
            Device = homeDevice,
            Detail = null,
        };

        _homeDeviceService.Setup(s => s.GetHomeDeviceByHardwareId(request.HardwareId))
            .Returns(homeDevice);

        _notificationService.Setup(s => s.AddMovementNotification(It.IsAny<CreateGenericNotificationArgs>()))
            .Returns([notification]);

        var result = _controller.MovementNotification(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Notification123", result[0].Id);
        Assert.AreEqual("Movement detected", result[0].Event);
    }
}
