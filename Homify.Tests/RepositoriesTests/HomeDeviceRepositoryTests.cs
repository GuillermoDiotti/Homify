using System.Linq.Expressions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class HomeDeviceRepositoryTests
{
    [TestMethod]
    public void Get_HomeDeviceExists_ReturnsHomeDevice()
    {
        var testData = new List<HomeDevice>
        {
            new HomeDevice
            {
                Id = "1",
                Device = new Device { Id = "1", Name = "Device1" },
                Home = new Home
                {
                    Id = "1",
                    Street = "Street1",
                    Number = "123",
                    Latitude = "45.0",
                    Longitude = "90.0",
                    MaxMembers = 5,
                    Owner = new HomeOwner { Id = "1", Name = "Owner1" },
                    Devices = [],
                    Members =
                    [
                        new HomeUser
                        {
                            Id = "1",
                            User = new User { Id = "1", Name = "User1" },
                            IsNotificable = true,
                            Permissions = []
                        }

                    ]
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<HomeDevice>>();
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomeDevice>()).Returns(mockSet.Object);

        var homeDeviceRepository = new HomeDeviceRepository(mockContext.Object);

        var result = homeDeviceRepository.Get(hd => hd.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Device1", result.Device.Name);
        Assert.AreEqual("Street1", result.Home.Street);
        Assert.AreEqual("123", result.Home.Number);
        Assert.AreEqual("45.0", result.Home.Latitude);
        Assert.AreEqual("90.0", result.Home.Longitude);
        Assert.AreEqual(5, result.Home.MaxMembers);
        Assert.AreEqual("Owner1", result.Home.Owner.Name);
        Assert.AreEqual(1, result.Home.Members.Count);
        Assert.AreEqual("User1", result.Home.Members.First().User.Name);
        Assert.IsTrue(result.Home.Members.First().IsNotificable);
    }

    [TestMethod]
    public void Get_WhenHomeDeviceDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<HomeDevice>>();
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Provider).Returns(new List<HomeDevice>().AsQueryable().Provider);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Expression).Returns(new List<HomeDevice>().AsQueryable().Expression);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.ElementType).Returns(new List<HomeDevice>().AsQueryable().ElementType);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.GetEnumerator()).Returns(new List<HomeDevice>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomeDevice>()).Returns(mockSet.Object);

        var homeDeviceRepository = new HomeDeviceRepository(mockContext.Object);
        Expression<Func<HomeDevice, bool>> predicate = hd => false;

        Assert.ThrowsException<NotFoundException>(() => homeDeviceRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredHomeDevices()
    {
        var testData = new List<HomeDevice>
        {
            new HomeDevice
            {
                Id = "1",
                Device = new Device { Id = "1", Name = "Device1" },
                Home = new Home
                {
                    Id = "1",
                    Street = "Street1",
                    Number = "123",
                    Latitude = "45.0",
                    Longitude = "90.0",
                    MaxMembers = 5,
                    Owner = new HomeOwner { Id = "1", Name = "Owner1" },
                    Devices = [],
                    Members =
                    [
                        new HomeUser
                        {
                            Id = "1",
                            User = new User { Id = "1", Name = "User1" },
                            IsNotificable = true,
                            Permissions = []
                        }

                    ]
                }
            },
            new HomeDevice
            {
                Id = "2",
                Device = new Device { Id = "2", Name = "Device2" },
                Home = new Home
                {
                    Id = "2",
                    Street = "Street2",
                    Number = "456",
                    Latitude = "46.0",
                    Longitude = "91.0",
                    MaxMembers = 6,
                    Owner = new HomeOwner { Id = "2", Name = "Owner2" },
                    Devices = [],
                    Members =
                    [
                        new HomeUser
                        {
                            Id = "2",
                            User = new User { Id = "2", Name = "User2" },
                            IsNotificable = true,
                            Permissions = []
                        }

                    ]
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<HomeDevice>>();
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<HomeDevice>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomeDevice>()).Returns(mockSet.Object);

        var homeDeviceRepository = new HomeDeviceRepository(mockContext.Object);

        var result = homeDeviceRepository.GetAll(hd => hd.Device.Name == "Device1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Device1", result[0].Device.Name);
    }
}
