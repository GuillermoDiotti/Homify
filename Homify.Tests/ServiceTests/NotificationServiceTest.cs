using System.Linq.Expressions;
using FluentAssertions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class NotificationServiceTest
{
    private Mock<IRepository<Notification>>? _mockRepository;
    private NotificationService? _notificationService;
    private Mock<IHomeUserService>? _mockHomeUserService;
    private Mock<IUserService>? _mockUserService;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IRepository<Notification>>();
        _mockHomeUserService = new Mock<IHomeUserService>();
        _mockUserService = new Mock<IUserService>();
        _notificationService = new NotificationService(_mockRepository.Object, _mockHomeUserService.Object, _mockUserService.Object);
    }

    [TestMethod]
    public void AddPersonDetectedNotification_ShouldAddNotifications_WhenUsersAreNotificable()
    {
        var homeDevice = new HomeDevice { Id = "Device123", HomeId = "Home123" };
        var homeUsers = new List<HomeUser>
        {
            new HomeUser { UserId = "User1", IsNotificable = true },
            new HomeUser { UserId = "User2", IsNotificable = false },
            new HomeUser { UserId = "User3", IsNotificable = true }
        };
        var detectedUser = new User { Id = "Person123", Name = "John", LastName = "Doe" };
        var notificationArgs = new CreateNotificationArgs("Person123", homeDevice, false, "Hardware123");

        _mockHomeUserService.Setup(s => s.GetHomeUsersByHomeId(homeDevice.HomeId)).Returns(homeUsers);
        _mockUserService.Setup(s => s.GetById("Person123")).Returns(detectedUser);

        var result = _notificationService.AddPersonDetectedNotification(notificationArgs);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Person Detected", result[0].Event);
        Assert.AreEqual("John Doe", result[0].Detail);
    }

    [TestMethod]
    public void AddWindowNotification_ShouldAddNotifications_WhenUsersAreNotificable()
    {
        var homeDevice = new HomeDevice { Id = "Device123", HomeId = "Home123" };
        var homeUsers = new List<HomeUser>
        {
            new HomeUser { UserId = "User1", IsNotificable = true },
            new HomeUser { UserId = "User2", IsNotificable = false },
            new HomeUser { UserId = "User3", IsNotificable = true }
        };
        var notificationArgs = new CreateGenericNotificationArgs(homeDevice, false, DateTimeOffset.Now, "Hardware123", "Window state switch detected", "Window opened");

        _mockHomeUserService.Setup(s => s.GetHomeUsersByHomeId(homeDevice.HomeId)).Returns(homeUsers);

        var result = _notificationService.AddWindowNotification(notificationArgs);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Window opened", result[0].Event);
        Assert.AreEqual("Window state switch detected", result[0].Detail);
        Assert.AreEqual("Window opened", result[1].Event);
        Assert.AreEqual("Window state switch detected", result[1].Detail);
    }

    [TestMethod]
    public void GetAllByUserId_ShouldReturnNotificationsForSpecificUser()
    {
        var userId = "user123";
        var notifications = new List<Notification>
        {
            new Notification
            {
                Id = "1",
                HomeUser = new HomeUser
                {
                    UserId = "user123"
                }
            },
            new Notification
            {
                Id = "2",
                HomeUser = new HomeUser
                {
                    UserId = "user456"
                }
            },
            new Notification
            {
                Id = "3",
                HomeUser = new HomeUser
                {
                    UserId = "user123"
                }
            }
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
            new Notification
            {
                Id = "1",
                HomeUser = new HomeUser
                {
                    UserId = "user123"
                }
            },
            new Notification
            {
                Id = "2",
                HomeUser = new HomeUser
                {
                    UserId = "user456"
                }
            }
        };

        _mockRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Notification, bool>>>())).Returns(notifications);

        var result = _notificationService.GetAllByUserId(userId);

        result.Should().BeEmpty();
    }

    [TestMethod]
    public void AddMovementNotification_WhenUsersAreNotificable_ShouldAddNotifications()
    {
        var homeDevice = new HomeDevice { Id = "Device123", HomeId = "Home123" };
        var homeUsers = new List<HomeUser>
        {
            new HomeUser { UserId = "User1", IsNotificable = true },
            new HomeUser { UserId = "User2", IsNotificable = false },
            new HomeUser { UserId = "User3", IsNotificable = true }
        };
        var not = new Notification(
            "Movement detected in home",
            homeDevice,
            false,
            homeUsers[0]);
        var notificationArgs = new CreateGenericNotificationArgs(homeDevice, false, DateTimeOffset.Now, "Hardware123", "Movement detected", null);

        _mockHomeUserService.Setup(s => s.GetHomeUsersByHomeId(homeDevice.HomeId)).Returns(homeUsers);

        var result = _notificationService.AddMovementNotification(notificationArgs);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Movement detected in home", result[0].Event);
        Assert.AreEqual("Movement detected", result[0].Detail);
    }

    [TestMethod]
    public void AddMovementNotification_WithNoNotificableUsers_ShouldNotAddNotification()
    {
        // Arrange
        var homeDevice = new HomeDevice
        {
            Id = "Device123",
            HomeId = "Home123",
            Device = new Device() { Id = "device123" },
            HardwareId = "kkk"
        };

        var homeUsers = new List<HomeUser>
        {
            new HomeUser { Id = "User1", UserId = "User1", IsNotificable = false },
            new HomeUser { Id = "User2", UserId = "User2", IsNotificable = false }
        };

        var notificationArgs =
            new CreateGenericNotificationArgs(homeDevice, false, DateTimeOffset.Now, homeDevice.HardwareId, "movement detected", null);

        _mockHomeUserService
            .Setup(service => service.GetHomeUsersByHomeId("Home123"))
            .Returns(homeUsers);

        // Act
        var result = _notificationService.AddMovementNotification(notificationArgs);

        // Assert
        Assert.IsNotNull(result);
        _mockRepository.Verify(repo => repo.Add(It.IsAny<Notification>()), Times.Never, "No notifications should be added if no users are notificable.");
        _mockHomeUserService.Verify(service => service.GetHomeUsersByHomeId("Home123"), Times.Once, "HomeUsers should be fetched once.");
        _mockUserService.Verify(service => service.GetById(It.IsAny<string>()), Times.Never, "No users should be fetched if no users are notificable.");
    }

    [TestMethod]
    public void ReadNotificationById_WithValidId_ShouldMarkAsRead()
    {
        var notificationId = "12345";
        var notification = new Notification
        {
            Id = notificationId,
            IsRead = false,
            HomeUser = new HomeUser() { UserId = "User1" }
        };

        _mockRepository
            .Setup(repo => repo.Get(It.IsAny<Expression<Func<Notification, bool>>>()))
            .Returns(notification);

        var result = _notificationService.ReadNotificationById(notificationId, new User()
        {
            Id = "User1"
        });

        Assert.IsNotNull(result);
        Assert.IsTrue(result.IsRead);

        _mockRepository.Verify(repo => repo.Get(It.IsAny<Expression<Func<Notification, bool>>>()), Times.Once);
        _mockRepository.Verify(repo => repo.Update(notification), Times.Once);
    }

    [TestMethod]
    public void Constructor_WithValidArguments_ShouldInitializeHomeDevice()
    {
        var homeDevice = new HomeDevice
        {
            Device = new Device { Type = "SupportedType" },
            IsActive = true
        };
        var type = "SupportedType";

        var result = new ValidateNotificationDeviceArgs(homeDevice, type);

        result.HomeDevice.Should().Be(homeDevice);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Constructor_WithNullHomeDevice_ShouldThrowNotFoundException()
    {
        new ValidateNotificationDeviceArgs(null, "SupportedType");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Constructor_WithUnsupportedDeviceType_ShouldThrowInvalidOperationException()
    {
        var homeDevice = new HomeDevice
        {
            Device = new Device { Type = "UnsupportedType" },
            IsActive = true
        };
        var type = "SupportedType";

        new ValidateNotificationDeviceArgs(homeDevice, type);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Constructor_WithInactiveDevice_ShouldThrowInvalidOperationException()
    {
        var homeDevice = new HomeDevice
        {
            Device = new Device { Type = "SupportedType" },
            IsActive = false
        };
        var type = "SupportedType";

        new ValidateNotificationDeviceArgs(homeDevice, type);
    }
}
