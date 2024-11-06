using System.Linq.Expressions;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
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
        var found = new HomeUser { Home = home, UserId = memberId, Permissions = new List<HomePermission>() };

        var _homeUserServiceMock = new Mock<IHomeUserService>();
        var _repositoryMock = new Mock<IRepository<HomePermission>>();
        var _service = new HomePermissionService(_repositoryMock.Object);

        _homeUserServiceMock.Setup(service => service.GetByIds(homeId, memberId)).Returns(found);

        _service.ChangeHomeMemberPermissions(true, true, user, found);
    }
}
