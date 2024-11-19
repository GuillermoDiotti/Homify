using System.Linq.Expressions;
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
                Name = "User1",
                Roles = new List<UserRole>
                {
                    new UserRole { Role = new Role { Name = "ADMINISTRATOR" } }
                }
            }
        }.AsQueryable();

        _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testData.Provider);
        _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testData.Expression);
        _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var result = _userRepository.Get(u => u.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Id);
        Assert.AreEqual("User1", result.Name);
        Assert.AreEqual("ADMINISTRATOR", result.Roles.First().Role.Name);
    }
}
