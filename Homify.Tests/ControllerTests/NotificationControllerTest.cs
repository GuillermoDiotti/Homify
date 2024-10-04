using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Notifications;
using Homify.WebApi.Controllers.Notifications.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class NotificationControllerTest
{
    private readonly Mock<INotificationService> _notificationService;
    private readonly Mock<IDeviceService> _deviceService;
    private readonly NotificationController _controller;

    public NotificationControllerTest()
    {
        _notificationService = new Mock<INotificationService>(MockBehavior.Strict);
        _deviceService = new Mock<IDeviceService>(MockBehavior.Strict);
        _controller = new NotificationController(_notificationService.Object, _deviceService.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void CreateNotification_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void CreateNotification_WhenDeviceIsNull_ShouldThrowNotFoundException()
    {
        var req = new CreateNotificationRequest()
        {
            DeviceId = "1",
            Date = DateTimeOffset.Now,
            Event = "Evento de prueba",
        };

        _deviceService.Setup(d => d.GetById(It.IsAny<string>())).Returns((Device?)null);

        _controller.Create(req);
    }

    [TestMethod]
    public void CreateNotification_WhenDataIsOk_ShouldCreateNotification()
    {
        var req = new CreateNotificationRequest()
        {
            DeviceId = "1",
            Date = DateTimeOffset.Now,
            Event = "Me afanaron la jarra electrica",
        };
        var device = new Device(){ Id = "1" };
        var homeDevice = new HomeDevice(){ Device = device };
        var expected = new Notification()
        {
            Date = req.Date,
            Event = req.Event,
            Device = homeDevice,
            IsRead = false,
            Id = Guid.NewGuid().ToString()
        };
        _deviceService.Setup(d => d.GetById(It.IsAny<string>())).Returns(device);
        _notificationService.Setup(n => n.AddNotification(It.IsAny<CreateNotificationArgs>())).Returns(expected);

        var result = _controller.Create(req);

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
            Name = "Test Device"
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
}
