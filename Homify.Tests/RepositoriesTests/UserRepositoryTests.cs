using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
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
                Email = "user1@example.com",
                Name = "User1",
                LastName = "LastName1",
                Password = "Password1",
                Role = RolesGenerator.Admin()
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

        var result1 = userRepository.Get(u => u.Id == "1");

        Assert.IsNotNull(result1);
        Assert.AreEqual("User1", result1.Name);
        Assert.AreEqual("LastName1", result1.LastName);
        Assert.AreEqual("user1@example.com", result1.Email);
        Assert.AreEqual("ADMINISTRATOR", result1.Role.Name);
    }

    [TestMethod]
    public void Get_WhenUserDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(new List<User>().AsQueryable().Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(new List<User>().AsQueryable().Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(new List<User>().AsQueryable().ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(new List<User>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

        var userRepository = new UserRepository(mockContext.Object);
        Expression<Func<User, bool>> predicate = user => false;

        Assert.ThrowsException<NotFoundException>(() => userRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredUsers()
    {
        var testData = new List<User>
        {
            new User
            {
                Id = "1",
                Name = "User1",
                Role = RolesGenerator.Admin()
            },
            new User
            {
                Id = "2",
                Name = "User2",
                Role = RolesGenerator.Admin()
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

        var result = userRepository.GetAll(u => u.Name == "User1");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("User1", result[0].Name);
    }
}
