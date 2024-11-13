using System.Linq.Expressions;
using Homify.BusinessLogic;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Moq;

namespace Homify.Tests.ServiceTests;

[TestClass]
public class HomeServiceTest
{
    private readonly Mock<IRepository<Home>> _mockRepository;
    private readonly HomeService _homeService;
    private readonly Mock<IDeviceService> _deviceService;
    private readonly Mock<IHomeDeviceService> _homeDeviceService;
    private readonly Mock<IUserService> _userService;

    public HomeServiceTest()
    {
        _userService = new Mock<IUserService>();
        _deviceService = new Mock<IDeviceService>();
        _mockRepository = new Mock<IRepository<Home>>();
        _homeDeviceService = new Mock<IHomeDeviceService>();
        _homeService = new HomeService(_mockRepository.Object, _deviceService.Object, _homeDeviceService.Object, _userService.Object);
    }

    [TestMethod]
    public void AddHome_ShouldCallRepositoryAdd_WithCorrectHome()
    {
        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles = [new UserRole() { UserId = "Owner123", Role = RolesGenerator.HomeOwner() }]
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
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMemberList_WhenUserIsNotHomeOwner_ShouldThrowNotFoundException()
    {
        var homeId = "homeId";
        var userMail = "nonhomeowner@example.com";
        var home = new Home
        {
            Id = homeId,
            Members = [],
            MaxMembers = 5
        };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _userService
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([
                new User { Email = userMail, Roles = [] }
            ]);

        _homeService.UpdateMemberList(homeId, userMail);
    }

    [TestMethod]
    public void UpdateMemberList_ShouldAddMemberAndUpdateHome()
    {
        var homeId = "home123";
        var userMail = "newmember@example.com";
        var userFound = new User
        {
            Id = "user123",
            Email = userMail,
            Roles = [new UserRole { RoleId = Constants.ADMINISTRATORID, UserId = "user123", Role = RolesGenerator.Admin() }]
        };
        userFound.Roles[0].Role.Name = Constants.HOMEOWNER;

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

        _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _userService
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([userFound]);
        var updatedHome = _homeService.UpdateMemberList(homeId, userMail);

        Assert.IsNotNull(updatedHome);
        Assert.AreEqual(homeId, updatedHome.Id);
        Assert.AreEqual(1, updatedHome.Members.Count);
        Assert.AreEqual(userFound.Id, updatedHome.Members[0].UserId);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void GetHomeDevices_WhenHomeIdIsNull_ShouldThrowNullRequestException()
    {
        string homeId = null;
        var user = new User { Id = "user123" };

        _homeService.GetHomeDevices(homeId, user);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMemberList_WhenMaxMembersReached_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var userMail = "newmember@example.com";
        var home = new Home
        {
            Id = homeId,
            Members = [new HomeUser()],
            MaxMembers = 1
        };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(home);
        _userService.Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([
                new User { Email = userMail, Roles = [new UserRole { Role = new Role { Name = Constants.HOMEOWNER } }] }
            ]);

        _homeService.UpdateMemberList(homeId, userMail);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMemberList_WhenHomeNotFound_ShouldThrowNotFoundException()
    {
        var homeId = "home123";
        var userMail = "test@example.com";

        _mockRepository.Setup(service => service.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns((Home)null);

        _homeService.UpdateMemberList(homeId, userMail);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMemberList_WhenHomeMembersListIsFull_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var userMail = "test@example.com";
        var homeFound = new Home
        {
            Id = homeId,
            Members = [new HomeUser(), new HomeUser(), new HomeUser()],
            MaxMembers = 3
        };

        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(homeFound);

        _homeService.UpdateMemberList(homeId, userMail);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMemberList_WhenUserNotFound_ShouldThrowNotFoundException()
    {
        var homeId = "home123";
        var userMail = "test@example.com";
        var homeFound = new Home
        {
            Id = homeId,
            Members = [],
            MaxMembers = 5
        };

        _mockRepository.Setup(service => service.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(homeFound);
        _userService
            .Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns([]);

        _homeService.UpdateMemberList(homeId, userMail);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMemberList_WhenUserAlreadyInHouse_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var userMail = "test@example.com";
        var homeFound = new Home
        {
            Id = homeId,
            Members = [new HomeUser { UserId = "user123" }],
            MaxMembers = 5
        };
        var userFound = new User
        {
            Id = "user123",
            Email = userMail,
            Roles =
            [
                new UserRole { UserId = "user123", RoleId = Constants.HOMEOWNERID, Role = RolesGenerator.HomeOwner() }
            ]
        };

        _mockRepository.Setup(service => service.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(homeFound);
        _userService.Setup(service => service.GetAll(It.IsAny<string?>(), It.IsAny<string?>())).Returns([userFound]);

        _homeService.UpdateMemberList(homeId, userMail);
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

        var members = new List<HomeUser>
        {
            new HomeUser
            {
                HomeId = homeId,
                Id = "123",
                UserId = memberId,
                IsNotificable = false
            },
            new HomeUser
            {
                HomeId = homeId,
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

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateHome_WhenUserIsNotOwner_ShouldThrowException()
    {
        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(new Home { Id = "homeId", OwnerId = "ownerId" });

        _homeService.UpdateHome("homeId", "alias", new User { Id = "userId" });
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UpdateHome_WhenAliasIsNull_ShouldThrowException()
    {
        _homeService.UpdateHome("homeId", null, new User { Id = "userId" });
    }

    [TestMethod]
    public void UpdateHome_When_ShouldUpdateHome()
    {
        var newAlias = "newAlias";
        var oldAlias = "oldAlias";
        _mockRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Home, bool>>>())).Returns(new Home { Id = "homeId", OwnerId = "ownerId", Alias = "oldAlias" });

        var reult = _homeService.UpdateHome("homeId", newAlias, new User { Id = "ownerId" });

        Assert.AreEqual(newAlias, reult.Alias);
    }

    [TestMethod]
    public void GetAllHomes_ReturnsHomesForUser()
    {
        // Arrange
        var user = new User { Id = "user1" };
        var homes = new List<Home>
        {
            new Home { Id = "home1", OwnerId = "user1" },
            new Home { Id = "home2", OwnerId = "user1" }
        };
        _mockRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(homes);

        var result = _homeService.GetAllHomesWhereUserIsOwner(user);

        _mockRepository.VerifyAll();
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.All(home => home.OwnerId == "user1"));
    }

    [TestMethod]
    public void GetAllHomes_ReturnsHomesForUser2()
    {
        // Arrange
        var user = new User { Id = "user1" };
        var hu1 = new HomeUser()
        {
            UserId = "user1"
        };
        var homes = new List<Home>()
        {
            new Home { Id = "home1", Members = [hu1] },
        };
        _mockRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Home, bool>>>()))
            .Returns(homes);

        var result = _homeService.GetAllHomesWhereUserIsMember(user);

        _mockRepository.VerifyAll();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }
}
