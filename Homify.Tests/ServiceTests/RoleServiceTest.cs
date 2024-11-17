using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

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
            Roles = [new UserRole { Role = RolesGenerator.HomeOwner() }]
        };

        _roleRepositoryMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Role, bool>>>()))
            .Returns(RolesGenerator.HomeOwner);

        Assert.ThrowsException<InvalidOperationException>(() => _service.AddRoleToUser(user));
    }

    [TestMethod]
    public void AddRoleToUser_WhenAllConditionsMet_DoesNotThrowException()
    {
        var mockRepository = new Mock<IRepository<Role>>();
        var mockUserService = new Mock<IUserService>();

        var adminRole = new Role { Name = Constants.ADMINISTRATOR };
        var companyOwnerRole = new Role { Name = Constants.COMPANYOWNER };
        var homeOwnerRole = new Role { Name = Constants.HOMEOWNER };

        mockRepository.Setup(repo => repo.Get(x => x.Name == Constants.ADMINISTRATOR)).Returns(adminRole);
        mockRepository.Setup(repo => repo.Get(x => x.Name == Constants.COMPANYOWNER)).Returns(companyOwnerRole);
        mockRepository.Setup(repo => repo.Get(x => x.Name == Constants.HOMEOWNER)).Returns(homeOwnerRole);

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Roles =
            [
                new UserRole { Role = adminRole },
                new UserRole { Role = companyOwnerRole }
            ]
        };

        var roleService = new RoleService(mockRepository.Object, mockUserService.Object);

        // Act
        roleService.AddRoleToUser(user);

        // Assert
        mockUserService.Verify(us => us.LoadIntermediateTable(user.Id, Constants.HOMEOWNERID), Times.Once);
    }
}
