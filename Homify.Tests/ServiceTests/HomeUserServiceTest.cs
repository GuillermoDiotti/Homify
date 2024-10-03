using System.Linq.Expressions;
using Homify.BusinessLogic.HomeUsers;
using Homify.DataAccess.Repositories;
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

        var result = _homeUserService.GetByIds(homeId, userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedHomeUser.HomeId, result.HomeId);
        Assert.AreEqual(expectedHomeUser.UserId, result.UserId);
        _mockRepository.Verify(r => r.Get(It.IsAny<Expression<Func<HomeUser, bool>>>()), Times.Once);
    }
}
