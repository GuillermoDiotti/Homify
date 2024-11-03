using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class UserRoleRepositoryTests
{
    [TestMethod]
    public void Get_UserRoleExists_ReturnsUserRole()
    {
        var testData = new List<UserRole>
        {
            new UserRole
            {
                Id = "1",
                User = new User
                {
                    Id = "1",
                    Name = "User1"
                },
                Role = new Role
                {
                    Id = "1",
                    Name = "ADMINISTRATOR"
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<UserRole>>();
        mockSet.As<IQueryable<UserRole>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<UserRole>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<UserRole>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<UserRole>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<UserRole>()).Returns(mockSet.Object);

        var userRoleRepository = new UserRoleRepository(mockContext.Object);

        var result = userRoleRepository.Get(ur => ur.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Id);
        Assert.AreEqual("User1", result.User.Name);
        Assert.AreEqual("ADMINISTRATOR", result.Role.Name);
    }
}
