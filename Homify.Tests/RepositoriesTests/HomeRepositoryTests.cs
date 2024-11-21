using System.Linq.Expressions;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class HomeRepositoryTests
{
    [TestMethod]
    public void Get_HomeExists_ReturnsHome()
    {
        var testData = new List<Home>
        {
            new Home
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
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Home>>();
        mockSet.As<IQueryable<Home>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Home>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Home>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Home>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Home>()).Returns(mockSet.Object);

        var homeRepository = new HomeRepository(mockContext.Object);

        var result = homeRepository.Get(h => h.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Street1", result.Street);
        Assert.AreEqual("123", result.Number);
        Assert.AreEqual("45.0", result.Latitude);
        Assert.AreEqual("90.0", result.Longitude);
        Assert.AreEqual(5, result.MaxMembers);
        Assert.AreEqual("Owner1", result.Owner.Name);
        Assert.AreEqual(1, result.Members.Count);
        Assert.AreEqual("User1", result.Members.First().User.Name);
        Assert.IsTrue(result.Members.First().IsNotificable);
    }

    [TestMethod]
    public void Get_WhenHomeDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<Home>>();
        mockSet.As<IQueryable<Home>>().Setup(m => m.Provider).Returns(new List<Home>().AsQueryable().Provider);
        mockSet.As<IQueryable<Home>>().Setup(m => m.Expression).Returns(new List<Home>().AsQueryable().Expression);
        mockSet.As<IQueryable<Home>>().Setup(m => m.ElementType).Returns(new List<Home>().AsQueryable().ElementType);
        mockSet.As<IQueryable<Home>>().Setup(m => m.GetEnumerator()).Returns(new List<Home>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Home>()).Returns(mockSet.Object);

        var homeRepository = new HomeRepository(mockContext.Object);
        Expression<Func<Home, bool>> predicate = h => false;

        Assert.ThrowsException<NotFoundException>(() => homeRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredHomes()
    {
        var testData = new List<Home>
        {
            new Home
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
            },
            new Home
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
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Home>>();
        mockSet.As<IQueryable<Home>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Home>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Home>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Home>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Home>()).Returns(mockSet.Object);

        var homeRepository = new HomeRepository(mockContext.Object);

        var result = homeRepository.GetAll(h => h.Id == "1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("1", result[0].Id);
    }
}
