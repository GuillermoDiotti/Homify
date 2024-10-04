using System.Linq.Expressions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeServiceTest
{
    private Mock<IRepository<Home>> _mockRepository;
    private HomeService _homeService;
    private Mock<IDeviceService> _deviceService;
    private Mock<IHomeDeviceService> _homeDeviceService;

    public HomeServiceTest()
    {
        _deviceService = new Mock<IDeviceService>();
        _mockRepository = new Mock<IRepository<Home>>();
        _homeDeviceService = new Mock<IHomeDeviceService>();
        _homeService = new HomeService(_mockRepository.Object, _deviceService.Object, _homeDeviceService.Object);
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

    [TestMethod]
    public void UpdateMemberList_ShouldAddMemberAndUpdateHome()
    {
        // Arrange
        var homeId = "home123";
        var homeOwner = new HomeUser { UserId = "owner123" };

        var home = new Home
        {
            Id = homeId,
            Members = new List<HomeUser>(),  // Initially no members
            Number = "123",
            Street = "Main St",
            Latitude = "45.0",
            Longitude = "-93.0",
            MaxMembers = 5
        };

        // Setup mock to return the home when Get is called
        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(home);

        // Act
        var updatedHome = _homeService.UpdateMemberList(homeId, homeOwner);

        // Assert
        Assert.IsNotNull(updatedHome);
        Assert.AreEqual(homeId, updatedHome.Id);
        Assert.AreEqual(1, updatedHome.Members.Count);  // Check if member was added
        Assert.AreEqual(homeOwner.UserId, updatedHome.Members[0].UserId);  // Check if correct member was added

        // Verify that the repository's Update method was called
        _mockRepository.Verify(r => r.Update(It.Is<Home>(h => h.Id == homeId && h.Members.Contains(homeOwner))), Times.Once);

        // Verify that the repository's Get method was called once
        _mockRepository.Verify(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()), Times.Once);
    }

    [TestMethod]
    public void UpdateHomeDevices_ShouldAddDeviceToHome_WhenUserHasPermission()
    {
        var homeId = "home1";
        var deviceId = "device1";
        var userId = "user1";
        var user = new User { Id = userId };
        var home = new Home
        {
            Id = homeId,
            OwnerId = userId,
            Members = new List<HomeUser>
            {
                new HomeUser { Id = userId, Permissions = new List<HomePermission> { new HomePermission() { Value = PermissionsGenerator.MemberCanAddDevice } } }
            },
            Devices = new List<HomeDevice>()
        };
        var device = new Device { Id = deviceId };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _deviceService.Setup(d => d.GetById(deviceId)).Returns(device);

        _homeService.UpdateHomeDevices(deviceId, homeId, user);

        _mockRepository.Verify(r => r.Update(It.Is<Home>(h => h.Devices.Any(d => d.DeviceId == deviceId))), Times.Once);
    }

    [TestMethod]
    public void GetHomeMembers_ShouldReturnListOfUsers_WhenUserIsOwner()
    {
        var homeId = "home1";
        var userId = "user1";
        var user = new User { Id = userId };
        var homeUser = new HomeUser { User = user };
        var home = new Home
        {
            Id = homeId,
            OwnerId = userId,
            Members = new List<HomeUser> { homeUser }
        };
        var homes = new List<Home> { home };

        _mockRepository.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(home);
        _mockRepository.Setup(r => r.GetAll(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(homes);

        var result = _homeService.GetHomeMembers(homeId, user);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(userId, result.First().Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetHomeMembers_ShouldThrowException_WhenUserIsNotOwner()
    {
        var homeId = "home1";
        var userId = "user1";
        var ownerId = "owner1";
        var user = new User { Id = userId };
        var home = new Home
        {
            Id = homeId,
            OwnerId = ownerId,
            Members = new List<HomeUser>()
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(home);

        _homeService.GetHomeMembers(homeId, user);
    }

    [TestMethod]
    public void GetHomeDevices_ShouldReturnDevices_WhenHomeExists()
    {
        // Arrange
        var homeId = "testHomeId";
        var user = new User {};
        var expectedDevices = new List<HomeDevice>
        {
            new HomeDevice {},
            new HomeDevice {}
        };

        var home = new Home
        {
            Id = homeId,
            Devices = expectedDevices
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(home);

        // Act
        var result = _homeService.GetHomeDevices(homeId, user);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDevices.Count, result.Count);
        CollectionAssert.AreEqual(expectedDevices, result);
    }

    [TestMethod]
    public void UpdateNotificatedList_ShouldUpdateUserAndReturnNotificableMembers_WhenUserExists()
    {
        // Arrange
        var homeId = "testHomeId";
        var memberId = "testMemberId";

        var members = new List<HomeUser>
        {
            new HomeUser { UserId = "testMemberId", IsNotificable = false },
            new HomeUser { UserId = "otherMemberId", IsNotificable = true }
        };

        var homeOwner = new HomeOwner() { Id = "123" };
        var home = new Home
        {
            Id = homeId,
            Members = members,
            Owner = homeOwner,
            OwnerId = homeOwner.Id,
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(home);

        // Act
        var result = _homeService.UpdateNotificatedList(homeId, memberId, homeOwner);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(members.First(m => m.UserId == memberId).IsNotificable);
        _mockRepository.Verify(r => r.Update(home), Times.Once);
    }
}
