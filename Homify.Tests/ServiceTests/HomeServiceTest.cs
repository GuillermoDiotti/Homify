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
using Homify.Exceptions;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeServiceTest
{
    private readonly Mock<IRepository<Home>> _mockRepository;
    private readonly HomeService _homeService;
    private readonly Mock<IDeviceService> _deviceService;
    private readonly Mock<IHomeDeviceService> _homeDeviceService;

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
        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Role = RolesGenerator.HomeOwner()
        };

        var createHomeArgs = new CreateHomeArgs("main", "123", "-54.3", "-55.4", 5, owner, "alias");

        var result = _homeService.AddHome(createHomeArgs);

        _mockRepository.Verify(r => r.Add(It.Is<Home>(h =>
            h.Latitude == createHomeArgs.Latitude &&
            h.Longitude == createHomeArgs.Longitude &&
            h.Number == createHomeArgs.Number &&
            h.Street == createHomeArgs.Street &&
            h.MaxMembers == createHomeArgs.MaxMembers &&
            h.Owner == owner &&
            h.Alias == createHomeArgs.Alias &&
            h.OwnerId == owner.Id)), Times.Once);

        Assert.IsNotNull(result);
        Assert.AreEqual(owner.Id, result.OwnerId);
    }

    [TestMethod]
    public void GetHomeById_ShouldReturnHome_WhenHomeExists()
    {
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

        var result = _homeService.GetHomeById(homeId);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedHome.Id, result.Id);
        Assert.AreEqual(expectedHome.Number, result.Number);
    }

    [TestMethod]
    public void UpdateMemberList_ShouldAddMemberAndUpdateHome()
    {
        var homeId = "home123";
        var homeOwner = new HomeUser
        {
            UserId = "owner123"
        };

        var home = new Home
        {
            Id = homeId,
            Members = [],
            Number = "123",
            Street = "Main St",
            Latitude = "45.0",
            Longitude = "-93.0",
            MaxMembers = 5
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(home);

        var updatedHome = _homeService.UpdateMemberList(homeId, homeOwner);

        Assert.IsNotNull(updatedHome);
        Assert.AreEqual(homeId, updatedHome.Id);
        Assert.AreEqual(1, updatedHome.Members.Count);
        Assert.AreEqual(homeOwner.UserId, updatedHome.Members[0].UserId);

        _mockRepository.Verify(r => r.Update(It.Is<Home>(h => h.Id == homeId && h.Members.Contains(homeOwner))), Times.Once);

        _mockRepository.Verify(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()), Times.Once);
    }

    [TestMethod]
    public void UpdateHomeDevices_ShouldAddDeviceToHome_WhenUserHasPermission()
    {
        var homeId = "home1";
        var deviceId = "device1";
        var userId = "user1";
        var user = new User
        {
            Id = userId
        };
        var home = new Home
        {
            Id = homeId,
            OwnerId = userId,
            Members =
            [
                new HomeUser
                {
                    Id = userId,
                    Permissions = [new HomePermission()
                    {
                        Value = PermissionsGenerator.MemberCanAddDevice
                    }

                    ]
                }

            ],
            Devices = []
        };
        var device = new Device
        {
            Id = deviceId
        };

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
        var user = new User
        {
            Id = userId
        };
        var homeUser = new HomeUser
        {
            User = user
        };
        var home = new Home
        {
            Id = homeId,
            OwnerId = userId,
            Members = [homeUser]
        };
        var homes = new List<Home>
        {
            home
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(home);
        _mockRepository.Setup(r => r.GetAll(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(homes);

        var result = _homeService.GetHomeMembers(homeId, user);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(userId, result.First().User.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetHomeMembers_ShouldThrowException_WhenUserIsNotOwner()
    {
        var homeId = "home1";
        var userId = "user1";
        var ownerId = "owner1";
        var user = new User
        {
            Id = userId
        };
        var home = new Home
        {
            Id = homeId,
            OwnerId = ownerId,
            Members = []
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Home, bool>>>()))
            .Returns(home);

        _homeService.GetHomeMembers(homeId, user);
    }

    [TestMethod]
    public void GetHomeDevices_WhenUserHasPermission_ShouldReturnDevices()
    {
        var homeId = "testHomeId";
        var userId = "testUserId";
        var user = new User { Id = userId };
        var homeDevices = new List<HomeDevice>
        {
            new HomeDevice { DeviceId = "device1" },
            new HomeDevice { DeviceId = "device2" }
        };

        var homeUser = new HomeUser
        {
            User = user,
            Permissions = [new HomePermission { Value = PermissionsGenerator.MemberCanListDevices }]
        };

        var home = new Home
        {
            Id = homeId,
            Members = [homeUser]
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _homeDeviceService.Setup(s => s.GetHomeDeviceByHomeId(homeId)).Returns(homeDevices);

        var result = _homeService.GetHomeDevices(homeId, user);

        Assert.IsNotNull(result);
        Assert.AreEqual(homeDevices.Count, result.Count);
        CollectionAssert.AreEqual(homeDevices, result);
    }

    [TestMethod]
    public void UpdateNotificatedList_ShouldUpdateUserAndReturnNotificableMembers_WhenUserExists()
    {
        var homeId = "testHomeId";
        var memberId = "testMemberId";
        var houseId = "HouseId";

        var members = new List<HomeUser>
        {
            new HomeUser
            {
                HomeId = houseId,
                Id = memberId,
                IsNotificable = false
            },
            new HomeUser
            {
                HomeId = houseId,
                Id = "otherMemberId",
                IsNotificable = true
            }
        };

        var homeOwner = new HomeOwner
        {
            Id = "123"
        };
        var home = new Home
        {
            Id = homeId,
            Owner = homeOwner,
            OwnerId = homeOwner.Id,
            Members = members
        };
        homeOwner.Homes.Add(home);

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(home);

        var result = _homeService.UpdateNotificatedList(homeId, memberId, homeOwner);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);

        Assert.IsTrue(members.First(m => m.Id == memberId).IsNotificable); // Cambiar UserId a Id

        var notificableMembers = result.Where(m => m.IsNotificable).ToList();
        Assert.AreEqual(2, notificableMembers.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetHomeDevices_WhenUserNotInHome_ShouldThrowException()
    {
        var homeId = "testHomeId";
        var userId = "testUserId";
        var user = new User { Id = userId };

        var home = new Home
        {
            Id = homeId,
            Members = []
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);

        _homeService.GetHomeDevices(homeId, user);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetHomeDevices_ShouldThrowException_WhenUserHasNoPermission()
    {
        var homeId = "testHomeId";
        var userId = "testUserId";
        var user = new User { Id = userId };

        var homeUser = new HomeUser
        {
            User = user,
            Permissions = []
        };

        var home = new Home
        {
            Id = homeId,
            Members = [homeUser]
        };

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);

        _homeService.GetHomeDevices(homeId, user);
    }

    [TestMethod]
    public void GetHomeById_WhenHomeNotFound_ShouldReturnNull()
    {
        var homeId = "nonexistentHomeId";
        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>()))
            .Throws(new NotFoundException("error"));

        var result = _homeService.GetHomeById(homeId);

        Assert.IsNull(result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateHomeDevices_WhenUserNotBelongingToHouse_ShouldThrowInvalidOperationException()
    {
        var deviceid = "device123";
        var homeid = "home123";
        var user = new User { Id = "user123" };
        var home = new Home { Id = homeid, OwnerId = "owner123", Members = [] };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);

        _homeService.UpdateHomeDevices(deviceid, homeid, user);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateHomeDevices_WhenUserHasNoPermission_ShouldThrowInvalidOperationException()
    {
        var deviceid = "device123";
        var homeid = "home123";
        var user = new User { Id = "user123" };
        var homeUser = new HomeUser { UserId = user.Id, Permissions = [] };
        var home = new Home { Id = homeid, OwnerId = "owner123", Members = [homeUser] };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);

        _homeService.UpdateHomeDevices(deviceid, homeid, user);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateHomeDevices_WhenDeviceNotFound_ShouldThrowNotFoundException()
    {
        var deviceid = "device123";
        var homeid = "home123";
        var user = new User { Id = "user123" };
        var homeUser = new HomeUser
        {
            UserId = user.Id,
            Permissions = [new HomePermission() { Value = PermissionsGenerator.MemberCanAddDevice }]
        };
        var home = new Home { Id = homeid, OwnerId = "owner123", Members = [homeUser] };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _deviceService.Setup(service => service.GetById(deviceid)).Returns((Device)null);

        _homeService.UpdateHomeDevices(deviceid, homeid, user);
    }
}
