using System.Linq.Expressions;
using FluentAssertions;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class NotificationServiceTest
{
    private Mock<IRepository<Notification>>? _mockRepository;
    private NotificationService? _notificationService;
    private Mock<IHomeDeviceService>? _mockHomeDeviceService;
    private Mock<IHomeUserService>? _mockHomeUserService;
    private Mock<IUserService>? _mockUserService;

    [TestInitialize]
    public void Setup()
    {
        _mockHomeDeviceService = new Mock<IHomeDeviceService>();
        _mockRepository = new Mock<IRepository<Notification>>();
        _mockHomeUserService = new Mock<IHomeUserService>();
        _mockUserService = new Mock<IUserService>();
        _notificationService = new NotificationService(_mockRepository.Object, _mockHomeDeviceService.Object, _mockHomeUserService.Object, _mockUserService.Object);
    }

    [TestMethod]
    public void AddPersonDetectedNotification_ShouldReturnNotification_WhenUserIsNotificable()
    {
        var homeDevice = new HomeDevice { Id = "Device123", HomeId = "Home123", HardwareId = "4444" };
        var homeUsers = new List<HomeUser>
        {
            new HomeUser { UserId = "User1", IsNotificable = true },
            new HomeUser { UserId = "User2", IsNotificable = false }
        };

        _mockHomeUserService.Setup(s => s.GetHomeUsersByHomeId(homeDevice.HomeId))
            .Returns(homeUsers);

        _mockUserService.Setup(s => s.GetById("User1"))
            .Returns(new User { Id = "User1" });

        var createNotificationArgs =
            new CreateNotificationArgs("1234567", homeDevice, false, DateTimeOffset.Now, homeDevice.HardwareId);

        var result = _notificationService.AddPersonDetectedNotification(createNotificationArgs);

        Assert.IsNotNull(result);
        Assert.AreEqual("Person Detected", result.Event);
        Assert.AreEqual(homeDevice.Id, result.HomeDeviceId);
        Assert.AreEqual("User1", result.HomeUserId);
        _mockRepository.Verify(r => r.Add(It.IsAny<Notification>()), Times.Once);
    }

    [TestMethod]
    public void AddWindowNotification_ShouldReturnNotification_WhenUserIsNotificable()
    {
        var homeDevice = new HomeDevice { Id = "Device123", HomeId = "Home123", HardwareId = "555" };
        var homeUsers = new List<HomeUser>
        {
            new HomeUser { UserId = "User1", IsNotificable = true },
            new HomeUser { UserId = "User2", IsNotificable = false }
        };

        _mockHomeUserService.Setup(s => s.GetHomeUsersByHomeId(homeDevice.HomeId))
            .Returns(homeUsers);

        _mockUserService.Setup(s => s.GetById("User1"))
            .Returns(new User { Id = "User1" });

        var createNotificationArgs =
            new CreateGenericNotificationArgs(homeDevice, false, DateTimeOffset.Now, homeDevice.HardwareId);

        var result = _notificationService.AddWindowNotification(createNotificationArgs);

        Assert.IsNotNull(result);
        Assert.AreEqual("Window state switch detected", result.Event);
        Assert.AreEqual(homeDevice.Id, result.HomeDeviceId);
        Assert.AreEqual("User1", result.HomeUserId);
        _mockRepository.Verify(r => r.Add(It.IsAny<Notification>()), Times.Once);
    }

    [TestMethod]
    public void GetAllByUserId_ShouldReturnNotificationsForSpecificUser()
    {
        var userId = "user123";
        var notifications = new List<Notification>
        {
            new Notification { Id = "1", HomeUser = new HomeUser { UserId = "user123" } },
            new Notification { Id = "2", HomeUser = new HomeUser { UserId = "user456" } },
            new Notification { Id = "3", HomeUser = new HomeUser { UserId = "user123" } }
        };

        _mockRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Notification, bool>>>())).Returns(notifications);

        var result = _notificationService.GetAllByUserId(userId);

        Assert.AreEqual(2, result.Count);
        result.Should().OnlyContain(n => n.HomeUser.UserId == userId);
    }

    [TestMethod]
    public void GetAllByUserId_ShouldReturnEmptyListForNonExistentUser()
    {
        var userId = "nonexistentUser";
        var notifications = new List<Notification>
        {
            new Notification { Id = "1", HomeUser = new HomeUser { UserId = "user123" } },
            new Notification { Id = "2", HomeUser = new HomeUser { UserId = "user456" } }
        };

        _mockRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Notification, bool>>>())).Returns(notifications);

        var result = _notificationService.GetAllByUserId(userId);

        result.Should().BeEmpty();
    }
}
