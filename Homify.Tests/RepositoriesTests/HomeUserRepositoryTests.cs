using System.Linq.Expressions;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class HomeUserRepositoryTests
{
    [TestMethod]
    public void Get_HomeUserExists_ReturnsHomeUser()
    {
        var testData = new List<HomeUser>
        {
            new HomeUser
            {
                Id = "1",
                User = new User
                {
                    Id = "1",
                    Name = "User1",
                    Roles = new List<UserRole>
                    {
                        new UserRole
                        {
                            Role = new Role
                            {
                                Name = "Admin"
                            }
                        }
                    }
                },
                Home = new Home
                {
                    Id = "1",
                    Street = "Street1",
                    Number = "123"
                },
                IsNotificable = true,
                Permissions = []
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<HomeUser>>();
        mockSet.As<IQueryable<HomeUser>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<HomeUser>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<HomeUser>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<HomeUser>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<HomeUser>()).Returns(mockSet.Object);

        var homeUserRepository = new HomeUserRepository(mockContext.Object);

        var result = homeUserRepository.Get(hu => hu.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("User1", result.User.Name);
        Assert.AreEqual("Admin", result.User.Roles.First().Role.Name);
        Assert.AreEqual("Street1", result.Home.Street);
        Assert.AreEqual("123", result.Home.Number);
        Assert.IsTrue(result.IsNotificable);
    }
}
