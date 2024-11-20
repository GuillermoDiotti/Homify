using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeUserServiceTest
{
    private Mock<IRepository<HomeUser>>? _mockRepository;
    private HomeUserService? _homeUserService;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IRepository<HomeUser>>();
        _homeUserService = new HomeUserService(_mockRepository.Object);
    }

    [TestMethod]
    public void GetByIds_ShouldReturnHomeUser_WhenHomeUserExists()
    {
        var homeId = "home123";
        var userId = "user123";

        var expectedHomeUser = new HomeUser
        {
            HomeId = homeId,
            UserId = userId,
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<HomeUser, bool>>>()))
            .Returns(expectedHomeUser);

        var result = _homeUserService.GetHomeUser(homeId, userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedHomeUser.HomeId, result.HomeId);
        Assert.AreEqual(expectedHomeUser.UserId, result.UserId);
        _mockRepository.Verify(r => r.Get(It.IsAny<Expression<Func<HomeUser, bool>>>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void GetByIds_ShouldThrowNotFoundException_WhenHomeUserDoesNotExist()
    {
        var homeId = "nonexistentHome";
        var userId = "nonexistentUser";
        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<HomeUser, bool>>>()))
            .Returns((HomeUser)null);

        _homeUserService.GetHomeUser(homeId, userId);
    }

    [TestMethod]
    public void Update_ShouldCallRepositoryUpdate_AndReturnUpdatedHomeUser()
    {
        var homeUser = new HomeUser
        {
            HomeId = "home123",
            UserId = "user123",
        };
        var result = _homeUserService.Update(homeUser);
        Assert.IsNotNull(result);
        Assert.AreEqual(homeUser.HomeId, result.HomeId);
        Assert.AreEqual(homeUser.UserId, result.UserId);
        _mockRepository.Verify(r => r.Update(It.Is<HomeUser>(u =>
            u.HomeId == homeUser.HomeId
            && u.UserId == homeUser.UserId)), Times.Once);
    }

    [TestMethod]
    public void GetHomeUsersByHomeId_ShouldReturnListOfHomeUsers_WhenHomeIdExists()
    {
        // Arrange
        var homeId = "home1";
        var homeUsers = new List<HomeUser>
        {
            new HomeUser
            {
                HomeId = homeId,
                UserId = "user1"
            },
            new HomeUser
            {
                HomeId = homeId,
                UserId = "user2"
            }
        };

        _mockRepository.Setup(r => r.GetAll(It.IsAny<System.Linq.Expressions.Expression<System.Func<HomeUser, bool>>>()))
            .Returns(homeUsers);

        // Act
        var result = _homeUserService.GetHomeUsersByHomeId(homeId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.All(hu => hu.HomeId == homeId));
    }
}
