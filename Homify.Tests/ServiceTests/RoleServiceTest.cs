using System.Linq.Expressions;
using Homify.BusinessLogic.Roles;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class RoleServiceTest
{
    private Mock<IRepository<Role>>? _roleRepositoryMock;

    private RoleService? _service;

    [TestInitialize]
    public void Setup()
    {
        _roleRepositoryMock = new Mock<IRepository<Role>>();
        _service = new RoleService(_roleRepositoryMock.Object);
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
}
