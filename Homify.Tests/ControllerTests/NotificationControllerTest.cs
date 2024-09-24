using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
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
    public void CreateNotification_WhenDataIsOk_ShouldCreateNotification()
    {
        var req = new CreateNotificationRequest()
        {
            DeviceId = "1", Date = DateTime.Now.ToString(), Event = "Me afanaron la jarra electrica",
        };
        var device = new Device();
        var expected = new Notification()
        {
            Date = req.Date, Event = req.Event, Device = device, IsRead = false, Id = Guid.NewGuid().ToString()
        };
        _deviceService.Setup(d => d.GetById(It.IsAny<string>())).Returns(device);
        _notificationService.Setup(n => n.AddNotification(It.IsAny<CreateNotificationArgs>())).Returns(expected);

        var result = _controller.Create(req);

        result.Id.Should().NotBeNull();
        result.Id.Should().Be(expected.Id);
    }
}
