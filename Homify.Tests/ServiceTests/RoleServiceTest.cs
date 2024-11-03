using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class RoleServiceTest
{
    private Mock<IRepository<Role>>? _roleRepositoryMock;
    private Mock<IUserService>? _userServiceMock;
    private RoleService? _service;

    [TestInitialize]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _roleRepositoryMock = new Mock<IRepository<Role>>();
        _service = new RoleService(_roleRepositoryMock.Object, _userServiceMock.Object);
    }

    [TestMethod]
    public void GetById_WhenDeviceExists_ShouldReturnRole()
    {
        var roleId = "test-role-id";
        var role = new Role
        {
            Id = roleId,
            Name = "Test role"
        };
        _roleRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Role, bool>>>()))
            .Returns(role);

        var result = _service.GetRole(roleId);

        Assert.IsNotNull(result);
        Assert.AreEqual(roleId, result.Id);
        Assert.AreEqual("Test role", result.Name);
    }

    [TestMethod]
    public void AddRole_WhenUserNotAdminOrCompanyOwner_ShouldThrowException()
    {
        var user = new User
        {
            Roles =
            [
                new UserRole { Role = new Role { Name = "Test role" } }
            ]
        };

        _roleRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Role, bool>>>()))
            .Returns(new Role
            {
                Name = "Test role"
            });

        Assert.ThrowsException<InvalidOperationException>(() => _service.AddRoleToUser(user));
    }
}
