using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.SystemPermissions;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class RoleRepositoryTests
{
    [TestMethod]
    public void Get_RoleExists_ReturnsRole()
    {
        var testData = new List<Role>
        {
            new Role
            {
                Id = "1",
                Name = "Admin",
                Permissions = new List<SystemPermission>
                {
                    new SystemPermission { Id = "1" },
                    new SystemPermission { Id = "2" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Role>>();
        mockSet.As<IQueryable<Role>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Role>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Role>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Role>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Role>()).Returns(mockSet.Object);

        var roleRepository = new RoleRepository(mockContext.Object);

        var result = roleRepository.Get(r => r.Id == "1");

        Assert.IsNotNull(result);
        Assert.AreEqual("Admin", result.Name);
        Assert.AreEqual(2, result.Permissions.Count);
    }

    [TestMethod]
    public void Get_WhenRoleDoesNotExist_ThrowsException()
    {
        var mockSet = new Mock<DbSet<Role>>();
        mockSet.As<IQueryable<Role>>().Setup(m => m.Provider).Returns(new List<Role>().AsQueryable().Provider);
        mockSet.As<IQueryable<Role>>().Setup(m => m.Expression).Returns(new List<Role>().AsQueryable().Expression);
        mockSet.As<IQueryable<Role>>().Setup(m => m.ElementType).Returns(new List<Role>().AsQueryable().ElementType);
        mockSet.As<IQueryable<Role>>().Setup(m => m.GetEnumerator()).Returns(new List<Role>().AsQueryable().GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Role>()).Returns(mockSet.Object);

        var roleRepository = new RoleRepository(mockContext.Object);
        Expression<Func<Role, bool>> predicate = r => false;

        Assert.ThrowsException<NotFoundException>(() => roleRepository.Get(predicate));
    }

    [TestMethod]
    public void GetAll_WithPredicate_ReturnsFilteredRoles()
    {
        var testData = new List<Role>
        {
            new Role
            {
                Id = "1",
                Name = "Admin",
                Permissions = new List<SystemPermission>
                {
                    new SystemPermission { Id = "1" },
                    new SystemPermission { Id = "2" }
                }
            },
            new Role
            {
                Id = "2",
                Name = "User",
                Permissions = new List<SystemPermission>
                {
                    new SystemPermission { Id = "3" }
                }
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Role>>();
        mockSet.As<IQueryable<Role>>().Setup(m => m.Provider).Returns(testData.Provider);
        mockSet.As<IQueryable<Role>>().Setup(m => m.Expression).Returns(testData.Expression);
        mockSet.As<IQueryable<Role>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        mockSet.As<IQueryable<Role>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

        var mockContext = new Mock<DbContext>();
        mockContext.Setup(c => c.Set<Role>()).Returns(mockSet.Object);

        var roleRepository = new RoleRepository(mockContext.Object);

        var result = roleRepository.GetAll(r => r.Name == "Admin");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Admin", result[0].Name);
    }
}
