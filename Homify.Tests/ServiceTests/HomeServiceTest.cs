using System.Linq.Expressions;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Roles;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeServiceTest
{
    private Mock<IRepository<Home>> _mockRepository;
    private HomeService _homeService;

    public HomeServiceTest()
    {
        _mockRepository = new Mock<IRepository<Home>>();
        _homeService = new HomeService(_mockRepository.Object);
    }

    [TestMethod]
    public void AddHome_ShouldCallRepositoryAdd_WithCorrectHome()
    {
        // Arrange
        var owner = new HomeOwner { Id = "Owner123", Name = "John Doe", Role = RolesGenerator.HomeOwner() };

        var createHomeArgs = new CreateHomeArgs("main", "123", "-54.3", "-55.4", 5, owner);

        // Act
        var result = _homeService.AddHome(createHomeArgs);

        // Assert
        _mockRepository.Verify(r => r.Add(It.Is<Home>(h =>
            h.Latitude == createHomeArgs.Latitude &&
            h.Longitude == createHomeArgs.Longitude &&
            h.Number == createHomeArgs.Number &&
            h.Street == createHomeArgs.Street &&
            h.MaxMembers == createHomeArgs.MaxMembers &&
            h.Owner == owner &&
            h.OwnerId == owner.Id
        )), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(owner.Id, result.OwnerId);
    }

    [TestMethod]
    public void GetHomeById_ShouldReturnHome_WhenHomeExists()
    {
        // Arrange
        var homeId = "home123";
        var expectedHome = new Home
        {
            Id = homeId,
            Number = "123",
            Street = "Main St",
            Latitude = "45.0",
            Longitude = "-93.1",
            MaxMembers = 5
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(expectedHome);

        // Act
        var result = _homeService.GetHomeById(homeId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedHome.Id, result.Id);
        Assert.AreEqual(expectedHome.Number, result.Number);
    }
}
