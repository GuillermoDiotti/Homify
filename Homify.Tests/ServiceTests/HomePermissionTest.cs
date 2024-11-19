using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomePermissionTest
{
    private Mock<IRepository<HomePermission>>? _repositoryMock;
    private HomePermissionService? _service;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<HomePermission>>();
        _service = new HomePermissionService(_repositoryMock.Object);
    }

    [TestMethod]
    public void GetByValue_ShouldReturnHomePermission_WhenValueExists()
    {
        var value = "testValue";
        var expectedPermission = new HomePermission { Value = value };
        _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomePermission, bool>>>()))
            .Returns(expectedPermission);

        var result = _service.GetByValue(value);

        Assert.IsNotNull(result);
        Assert.AreEqual(value, result.Value);
    }

    [TestMethod]
    public void GetByValue_ShouldReturnNull_WhenValueDoesNotExist()
    {
        _repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<HomePermission, bool>>>()))
            .Returns((HomePermission)null);

        var result = _service.GetByValue("nonExistingValue");

        Assert.IsNull(result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ChangeHomeMemberPermissions_WhenUserIsNotOwner_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var memberId = "member123";
        var user = new User { Id = "notOwner123" };
        var home = new Home { Id = homeId, OwnerId = "owner123" };
        var found = new HomeUser { Home = home, UserId = memberId, Permissions = [] };

        var homeUserServiceMock = new Mock<IHomeUserService>();
        var repositoryMock = new Mock<IRepository<HomePermission>>();
        var service = new HomePermissionService(repositoryMock.Object);

        homeUserServiceMock.Setup(service => service.GetHomeUser(homeId, memberId)).Returns(found);

        service.ChangeHomeMemberPermissions(true, true, true, user, found);
    }

    [TestMethod]
    public void ChangeHomeMemberPermissions_AddDeviceTrue_AddsCorrectPermission()
    {
        var user = new User { Id = "1" };
        var homeUser = new HomeUser { Home = new Home { OwnerId = "1" } };
        var permission = new HomePermission { Value = PermissionsGenerator.MemberCanAddDevice };
        _repositoryMock.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<HomePermission, bool>>>()))
            .Returns(permission);

        var result = _service.ChangeHomeMemberPermissions(true, false, false, user, homeUser);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(PermissionsGenerator.MemberCanAddDevice, result[0].Value);
    }

    [TestMethod]
    public void ChangeHomeMemberPermissions_ListDeviceTrue_AddsCorrectPermission()
    {
        var user = new User { Id = "1" };
        var homeUser = new HomeUser { Home = new Home { OwnerId = "1" } };
        var permission = new HomePermission { Value = PermissionsGenerator.MemberCanListDevices };
        _repositoryMock.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<HomePermission, bool>>>()))
            .Returns(permission);

        var result = _service.ChangeHomeMemberPermissions(false, true, false, user, homeUser);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(PermissionsGenerator.MemberCanListDevices, result[0].Value);
    }
}
