using System.Linq.Expressions;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class UserRoleServiceTest
{
    private Mock<IRepository<UserRole>>? _userRoleRepositoryMock;
    private UserRoleService? _service;

    [TestInitialize]
    public void Setup()
    {
        _userRoleRepositoryMock = new Mock<IRepository<UserRole>>();
        _service = new UserRoleService(_userRoleRepositoryMock.Object);
    }

    [TestMethod]
    public void GetRolesByUserId_WhenRolesExist_ShouldReturnRoles()
    {
        var userId = "test-user-id";
        var roles = new List<UserRole>
        {
            new UserRole
            {
                UserId = userId,
                Role = new Role { Id = "role1", Name = "Role 1" }
            },
            new UserRole
            {
                UserId = userId,
                Role = new Role { Id = "role2", Name = "Role 2" }
            }
        };

        _userRoleRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<UserRole, bool>>>()))
            .Returns(roles);

        var result = _service.GetRolesByUserId(userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("role1", result[0].Id);
        Assert.AreEqual("Role 1", result[0].Name);
        Assert.AreEqual("role2", result[1].Id);
        Assert.AreEqual("Role 2", result[1].Name);
    }
}
