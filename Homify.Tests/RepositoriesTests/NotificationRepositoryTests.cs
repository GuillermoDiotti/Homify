using System.Linq.Expressions;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class NotificationRepositoryTests
{
    [TestMethod]
    public void Get_NotificationExists_ReturnsNotification()
    {
        var testData = new List<Notification>
        {
            new Notification
            {
                Id = "1",
                Device = new HomeDevice { Id = "1" },
                HomeUser = new HomeUser
                {
                    Id = "1",
                    User = new User { Id = "1", Name = "User1" },
                    Home = new Home { Id = "1", Street = "Street1", Number = "123" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Notification>>();
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Notification>()).Returns(mockSet.Object);

        var notificationRepository = new NotificationRepository(mockContext.Object);

        var result = notificationRepository.Get(n => n.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Device.Id);
        Assert.AreEqual("User1", result.HomeUser.User.Name);
        Assert.AreEqual("Street1", result.HomeUser.Home.Street);
        Assert.AreEqual("123", result.HomeUser.Home.Number);
    }

    [TestMethod]
    public void Get_WhenNotificationDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<Notification>>();
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Provider).Returns(new List<Notification>().AsQueryable().Provider);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Expression).Returns(new List<Notification>().AsQueryable().Expression);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.ElementType).Returns(new List<Notification>().AsQueryable().ElementType);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.GetEnumerator()).Returns(new List<Notification>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Notification>()).Returns(mockSet.Object);

        var notificationRepository = new NotificationRepository(mockContext.Object);
        Expression<Func<Notification, bool>> predicate = n => false;

        Assert.ThrowsException<NotFoundException>(() => notificationRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredNotifications()
    {
        var testData = new List<Notification>
        {
            new Notification
            {
                Id = "1",
                Device = new HomeDevice { Id = "1" },
                HomeUser = new HomeUser
                {
                    Id = "1",
                    User = new User { Id = "1", Name = "User1" },
                    Home = new Home { Id = "1", Street = "Street1", Number = "123" }
                }
            },
            new Notification
            {
                Id = "2",
                Device = new HomeDevice { Id = "2" },
                HomeUser = new HomeUser
                {
                    Id = "2",
                    User = new User { Id = "2", Name = "User2" },
                    Home = new Home { Id = "2", Street = "Street2", Number = "456" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Notification>>();
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Notification>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Notification>()).Returns(mockSet.Object);

        var notificationRepository = new NotificationRepository(mockContext.Object);

        var result = notificationRepository.GetAll(n => n.Device.Id == "1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("1", result[0].Device.Id);
    }
}
