using System.Linq.Expressions;
using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class UserRepositoryTests
{
    [TestMethod]
    public void Get_UserExists_ReturnsUser()
    {
        var testData = new List<User>
        {
            new User
            {
                Id = "1",
                Name = "John",
                LastName = "Doe",
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        Role = new Role
                        {
                            Name = "Admin",
                            Permissions = [new SystemPermission { Value = "Read" }]
                        }
                    }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

        var userRepository = new UserRepository(mockContext.Object);

        var result = userRepository.Get(u => u.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("John", result.Name);
        Assert.AreEqual("Admin", result.Roles.First().Role.Name);
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredUsers()
    {
        var testData = new List<User>
        {
            new User { Id = "1", Name = "John", LastName = "Doe" },
            new User { Id = "2", Name = "Jane", LastName = "Smith" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

        var userRepository = new UserRepository(mockContext.Object);

        var result = userRepository.GetAll(u => u.Name == "John");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("John", result[0].Name);
    }

    [TestMethod]
    public void GetAll_NullPredicate_ReturnsAllUsers()
    {
        var testData = new List<User>
        {
            new User { Id = "1", Name = "John", LastName = "Doe" },
            new User { Id = "2", Name = "Jane", LastName = "Smith" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

        var userRepository = new UserRepository(mockContext.Object);

        var result = userRepository.GetAll(null);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("John", result[0].Name);
        Assert.AreEqual("Jane", result[1].Name);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Get_UserNotFound_ThrowsNotFoundException()
    {
        var testData = new List<User>
        {
            new User { Id = "1", Name = "John", LastName = "Doe" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

        var userRepository = new UserRepository(mockContext.Object);

        userRepository.Get(u => u.Id == "999");
    }
}
