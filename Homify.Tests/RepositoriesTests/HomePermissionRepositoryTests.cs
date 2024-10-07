using System.Linq.Expressions;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class HomePermissionRepositoryTests
{
    [TestMethod]
    public void Get_HomePermissionExists_ReturnsHomePermission()
    {
        var testData = new List<HomePermission>
        {
            new HomePermission
            {
                Id = "1",
                HomeUsers = new List<HomeUser>
                {
                    new HomeUser
                    {
                        Id = "1",
                        User = new User { Id = "1", Name = "User1" },
                        IsNotificable = true,
                        Permissions = new List<HomePermission>()
                    }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<HomePermission>>();
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomePermission>()).Returns(mockSet.Object);

        var homePermissionRepository = new HomePermissionRepository(mockContext.Object);

        var result = homePermissionRepository.Get(hp => hp.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.HomeUsers.Count);
        Assert.AreEqual("User1", result.HomeUsers.First().User.Name);
    }

    [TestMethod]
    public void Get_WhenHomePermissionDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<HomePermission>>();
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Provider).Returns(new List<HomePermission>().AsQueryable().Provider);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Expression).Returns(new List<HomePermission>().AsQueryable().Expression);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.ElementType).Returns(new List<HomePermission>().AsQueryable().ElementType);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.GetEnumerator()).Returns(new List<HomePermission>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomePermission>()).Returns(mockSet.Object);

        var homePermissionRepository = new HomePermissionRepository(mockContext.Object);
        Expression<Func<HomePermission, bool>> predicate = hp => false;

        Assert.ThrowsException<NotFoundException>(() => homePermissionRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredHomePermissions()
    {
        var testData = new List<HomePermission>
        {
            new HomePermission
            {
                Id = "1",
                HomeUsers = new List<HomeUser>
                {
                    new HomeUser
                    {
                        Id = "1",
                        User = new User { Id = "1", Name = "User1" },
                        IsNotificable = true,
                        Permissions = new List<HomePermission>()
                    }
                }
            },
            new HomePermission
            {
                Id = "2",
                HomeUsers = new List<HomeUser>
                {
                    new HomeUser
                    {
                        Id = "2",
                        User = new User { Id = "2", Name = "User2" },
                        IsNotificable = true,
                        Permissions = new List<HomePermission>()
                    }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<HomePermission>>();
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<HomePermission>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomePermission>()).Returns(mockSet.Object);

        var homePermissionRepository = new HomePermissionRepository(mockContext.Object);

        var result = homePermissionRepository.GetAll(hp => hp.Id == "1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("1", result[0].Id);
    }
}
