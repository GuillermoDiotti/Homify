using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Controllers.Homes;
using Homify.WebApi.Controllers.Homes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;
[TestClass]
public class HomesControllerTest
{
    private readonly HomeController? _controller;
    private readonly Mock<IHomeService>? _homeServiceMock;
    private readonly Mock<IUserService>? _userServiceMock;
    private readonly Mock<IHomeUserService> _homeUserServiceMock;
    private readonly Mock<IHomePermissionService> _homePermissionServiceMock;
    public HomesControllerTest()
    {
        _homeServiceMock = new Mock<IHomeService>(MockBehavior.Strict);
        _userServiceMock = new Mock<IUserService>(MockBehavior.Strict);
        _homeUserServiceMock = new Mock<IHomeUserService>(MockBehavior.Strict);
        _homePermissionServiceMock = new Mock<IHomePermissionService>(MockBehavior.Strict);
        _controller = new HomeController(_homeServiceMock.Object, _userServiceMock.Object, _homeUserServiceMock.Object, _homePermissionServiceMock.Object);
    }

    [TestMethod]
    public void GetHomeAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var home = new Home()
        {
            Id = "home123",
            Street = "calle 1",
            Number = "1",
            Latitude = "101",
            Longitude = "202",
            MaxMembers = 3,
            Owner = new HomeOwner
            {
                Name = "Owner Name"
            },
            Devices = [],
        };

        home.Id.Should().Be("home123");
        home.Street.Should().Be("calle 1");
        home.Number.Should().Be("1");
        home.Latitude.Should().Be("101");
        home.Longitude.Should().Be("202");
        home.MaxMembers.Should().Be(3);
        home.Owner.Name.Should().Be("Owner Name");
        home.Devices.Should().BeEmpty();
    }

    [TestMethod]
    public void GetHomePermissionAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var homepermission = new HomePermission()
        {
            Id = "123",
            Value = "calle 1"
        };

        homepermission.Id.Should().Be("123");
        homepermission.Value.Should().Be("calle 1");
    }

    [TestMethod]
    public void GetHomeDeviceAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var homedevice = new HomeDevice()
        {
            HomeId = "home123",
            DeviceId = "device123",
            Home = new Home
            {
                Id = "home123"
            },
            Device = new Device
            {
                Id = "device123"
            },
            Connected = true,
            HardwareId = "1001",
        };

        homedevice.HomeId.Should().Be("home123");
        homedevice.DeviceId.Should().Be("device123");
        homedevice.Home.Id.Should().Be("home123");
        homedevice.Device.Id.Should().Be("device123");
        homedevice.Connected.Should().BeTrue();
        homedevice.HardwareId.Should().Be("1001");
    }

    [TestMethod]
    public void GetHomeUsersAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var homeuser = new HomeUser()
        {
            HomeId = "home123",
            UserId = "device123",
            Home = new Home
            {
                Id = "home123"
            },
            User = new User
            {
                Id = "device123"
            },
            IsNotificable = true,
        };
        var permission = new HomePermission()
        {
            Id = "123",
            Value = "calle 1"
        };
        homeuser.Permissions =
        [
            permission
        ];

        homeuser.HomeId.Should().Be("home123");
        homeuser.UserId.Should().Be("device123");
        homeuser.Home.Id.Should().Be("home123");
        homeuser.User.Id.Should().Be("device123");
        homeuser.IsNotificable.Should().BeTrue();
        homeuser.Permissions.Should().NotBeNull();
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void Create_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenStreetIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = null,
            Number = "3",
            Latitude = "141",
            Longitud = "231",
            MaxMembers = 1
        };

        var user = new User
        {
            Id = "User123"
        };
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenNumberIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = null,
            Latitude = "141",
            Longitud = "231",
            MaxMembers = 1
        };

        var user = new User
        {
            Id = "User123"
        };
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenLatitudeIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = "3",
            Latitude = null
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Role = RolesGenerator.HomeOwner()
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;

        _controller.ControllerContext.HttpContext = httpContext;

        _controller.Create(request);
    }

    [TestMethod]
    public void CreateHome_WhenLongitudIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = "3",
            Latitude = "141",
            Longitud = null
        };

        var user = new User
        {
            Id = "User123"
        };
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        Assert.ThrowsException<ArgsNullException>(() => _controller.Create(request));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenMaxMembersIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = "3",
            Latitude = "141",
            Longitud = "231",
            MaxMembers = 0
        };

        var user = new User
        {
            Id = "User123"
        };
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.Create(request);
    }

    [TestMethod]
    public void Create_WithValidRequest_ShouldReturnCreateHomeResponse()
    {
        // Arrange
        var request = new CreateHomeRequest
        {
            Street = "calle 1",
            Number = "1",
            Latitude = "101",
            Longitud = "202",
            MaxMembers = 3,
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Role = RolesGenerator.HomeOwner()
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;

        _controller.ControllerContext.HttpContext = httpContext;

        var expectedHome = new Home("calle 1", "1", "101", "202", 3, owner, [], []);

        _homeServiceMock.Setup(service => service.AddHome(It.IsAny<CreateHomeArgs>()))
            .Returns(expectedHome);

        var response = _controller.Create(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(expectedHome.Id, response.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevices_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.UpdateHomeDevice(null, "home123");
    }

    [TestMethod]
    public void UpdateHomeDevice_WhenRequestIsValid_ShouldCallServiceToUpdateDevice()
    {
        var request = new UpdateHomeDevicesRequest
        {
            DeviceId = "device123"
        };

        var user = new User
        {
            Id = "user123"
        };
        var updatedDevice = new HomeDevice
        {
            DeviceId = "device123",
            HomeId = "home1",
            Home = new Home
            {
                Id = "home1"
            },
            Device = new Device
            {
                Id = "device123"
            },
            Connected = true,
            HardwareId = "1001"
        };

        _homeServiceMock.Setup(service => service.UpdateHomeDevices(request.DeviceId, "home1", user)).Returns(updatedDevice);

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        var result = _controller.UpdateHomeDevice(request, "home1");

        _homeServiceMock.Verify(service => service.UpdateHomeDevices(request.DeviceId, "home1", user), Times.Once);
    }

    [TestMethod]
    public void GetHomeDevices_WhenCalled_ShouldReturnListOfDevices()
    {
        var homeId = "home123";
        var user = new User
        {
            Id = "user123",
            Name = "John Doe"
        };
        var devices = new List<HomeDevice>
        {
            new HomeDevice
            {
                Id = "1",
                DeviceId = "device1",
                HomeId = homeId,
                Connected = true,
                IsActive = true,
                HardwareId = "hardware1",
                Device = new Device
                {
                    Name = "Device 1",
                    Model = "Model A"
                }
            },
            new HomeDevice
            {
                Id = "2",
                DeviceId = "device2",
                HomeId = homeId,
                Connected = false,
                IsActive = false,
                HardwareId = "hardware2",
                Device = new Device
                {
                    Name = "Device 2",
                    Model = "Model B"
                }
            }
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _homeServiceMock.Setup(service => service.GetHomeDevices(homeId, user)).Returns(devices);

        var result = _controller.ObtainHomeDevices(homeId);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateNotificatorsList_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.NotificatedMembers("homeIe", null);
    }

    [TestMethod]
    public void NotificatedMembers_WhenRequestIsValid_ShouldReturnNotificatedMembersResponse()
    {
        var homeId = "home123";
        var request = new NotificatedMembersRequest
        {
            HomeUserId = "user1"
        };
        var user = new User { Id = "testUserId" };
        var updatedMembers = new List<HomeUser>
        {
            new HomeUser { Id = "user1" },
            new HomeUser { Id = "user2" }
        };

        _homeServiceMock.Setup(service => service.UpdateNotificatedList(homeId, request.HomeUserId, user)).Returns(updatedMembers);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var result = _controller.NotificatedMembers(homeId, request);

        result.Should().NotBeNull();
        result.MembersToNotify.Should().BeEquivalentTo(new List<string> { "user1", "user2" });
        _homeServiceMock.Verify(service => service.UpdateNotificatedList(homeId, request.HomeUserId, user), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void ChangeHomeMemberPermissions_ShouldThrowNullRequestException_WhenRequestIsNull()
    {
        _controller.ChangeHomeMemberPermissions("home123", "member123", null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void ObtainMembers_WhenHomeDoesNotExist_ShouldThrowNotFoundException()
    {
        var homeId = "homeNotFound";
        var user = new User
        {
            Id = "user123"
        };

        _homeServiceMock.Setup(service => service.GetHomeMembers(homeId, user)).Throws(new NotFoundException("Home not found"));

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.ObtainMembers(homeId);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ObtainMembers_WhenUserIsNotHomeOwner_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var user = new User
        {
            Id = "userNotOwner"
        };
        var members = new List<HomeUser>
        {
            new HomeUser
            {
                UserId = "member1",
                HomeId = homeId
            }
        };

        _homeServiceMock.Setup(service => service.GetHomeMembers(homeId, user)).Throws(new InvalidOperationException("Only the owner can see the members"));

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.ObtainMembers(homeId);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateMembersList_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        _controller.UpdateMembersList("home123", null);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMembersList_WhenHomeDoesNotExist_ShouldThrowNotFoundException()
    {
        var homeId = "homeNotFound";
        var request = new UpdateMemberListRequest
        {
            Email = "newmember@example.com"
        };
        var user = new User
        {
            Id = "ownerId",
            Role = new Role
            {
                Name = Constants.HOMEOWNER
            }
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns((Home)null); // Home not found

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMembersList_WhenMaxMembersReached_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest
        {
            Email = "newmember@example.com"
        };
        var user = new User
        {
            Id = "ownerId",
            Role = new Role
            {
                Name = Constants.HOMEOWNER
            }
        };
        var home = new Home
        {
            Id = homeId,
            Members = [new HomeUser()],
            MaxMembers = 1
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns(home);

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    public void ObtainMembers_WhenHomeIdIsValid_ShouldReturnMembersList()
    {
        // Arrange
        var homeId = "home123";
        var user = new User { Id = "testUserId" };
        var homeMembers = new List<HomeUser>
        {
            new HomeUser
            {
                UserId = "user1",
                HomeId = homeId,
                User = new User { Id = "user1" },
                Home = new Home { Id = homeId },
                IsNotificable = true
            },
            new HomeUser
            {
                UserId = "user2",
                HomeId = homeId,
                User = new User { Id = "user2" },
                Home = new Home { Id = homeId },
                IsNotificable = true
            }
        };

        _homeServiceMock.Setup(service => service.GetHomeMembers(homeId, user)).Returns(homeMembers);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        // Act
        var result = _controller.ObtainMembers(homeId);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(2);
        result[0].Should().BeEquivalentTo(new GetMemberResponse(homeMembers[0]));
        result[1].Should().BeEquivalentTo(new GetMemberResponse(homeMembers[1]));
        _homeServiceMock.Verify(service => service.GetHomeMembers(homeId, user), Times.Once);
    }

    [TestMethod]
    public void UpdateMembersList_WhenRequestIsValid_ShouldReturnUpdateMembersListResponse()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest
        {
            Email = "test@example.com"
        };
        var homeFound = new Home
        {
            Id = homeId,
            Members = new List<HomeUser>(),
            MaxMembers = 5
        };
        var userFound = new User
        {
            Id = "user123",
            Email = "test@example.com",
            Role = new Role { Name = Constants.HOMEOWNER }
        };
        var homeUser = new HomeUser
        {
            Home = homeFound,
            IsNotificable = false,
            User = userFound,
            HomeId = homeId,
            UserId = userFound.Id,
            Permissions = new List<HomePermission>()
        };
        var updatedHome = new Home
        {
            Id = homeId,
            Members = new List<HomeUser> { homeUser },
            MaxMembers = 5
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns(homeFound);
        _userServiceMock.Setup(service => service.GetAll()).Returns(new List<User> { userFound });
        _homeServiceMock.Setup(service => service.UpdateMemberList(homeId, It.Is<HomeUser>(hu => hu.UserId == homeUser.UserId))).Returns(updatedHome);

        var result = _controller.UpdateMembersList(homeId, request);

        result.Should().NotBeNull();
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateMembersList_WhenRequestIsNul_ShouldThrowNullRequestException()
    {
        var homeId = "home123";
        UpdateMemberListRequest? request = null;

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMembersList_WhenHomeNotFound_ShouldThrowNotFoundException()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest { Email = "test@example.com" };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns((Home)null);

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMembersList_WhenHomeMembersListIsFull_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest { Email = "test@example.com" };
        var homeFound = new Home
        {
            Id = homeId,
            Members = new List<HomeUser> { new HomeUser(), new HomeUser(), new HomeUser() },
            MaxMembers = 3
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns(homeFound);

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void UpdateMembersList_WhenUserNotFound_ShouldThrowNotFoundException()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest { Email = "test@example.com" };
        var homeFound = new Home
        {
            Id = homeId,
            Members = new List<HomeUser>(),
            MaxMembers = 5
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns(homeFound);
        _userServiceMock.Setup(service => service.GetAll()).Returns(new List<User>());

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UpdateMembersList_WhenUserAlreadyInHouse_ShouldThrowInvalidOperationException()
    {
        var homeId = "home123";
        var request = new UpdateMemberListRequest { Email = "test@example.com" };
        var homeFound = new Home
        {
            Id = homeId,
            Members = new List<HomeUser> { new HomeUser { UserId = "user123" } },
            MaxMembers = 5
        };
        var userFound = new User
        {
            Id = "user123",
            Email = "test@example.com",
            Role = new Role { Name = Constants.HOMEOWNER }
        };

        _homeServiceMock.Setup(service => service.GetHomeById(homeId)).Returns(homeFound);
        _userServiceMock.Setup(service => service.GetAll()).Returns(new List<User> { userFound });

        _controller.UpdateMembersList(homeId, request);
    }

    [TestMethod]
    public void ChangeHomeMemberPermissions_WhenRequestIsValid_ShouldReturnHomeMemberBasicInfo()
    {
        var homeId = "home123";
        var memberId = "member123";
        var request = new EditMemberPermissionsRequest
        {
            CanAddDevices = true,
            CanListDevices = true
        };
        var home = new Home
        {
            Id = homeId,
            OwnerId = "owner123"
        };
        var found = new HomeUser
        {
            Home = home,
            UserId = memberId,
            Permissions = new List<HomePermission>()
        };
        var user = new User
        {
            Id = "owner123"
        };
        var permissionAddDevice = new HomePermission
        {
            Value = PermissionsGenerator.MemberCanAddDevice
        };
        var permissionListDevices = new HomePermission
        {
            Value = PermissionsGenerator.MemberCanListDevices
        };

        _homeUserServiceMock.Setup(service => service.GetByIds(homeId, memberId)).Returns(found);
        _homePermissionServiceMock.Setup(service => service.GetByValue(PermissionsGenerator.MemberCanAddDevice)).Returns(permissionAddDevice);
        _homePermissionServiceMock.Setup(service => service.GetByValue(PermissionsGenerator.MemberCanListDevices)).Returns(permissionListDevices);
        _homeUserServiceMock.Setup(service => service.Update(It.IsAny<HomeUser>())).Returns(found);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;
        var result = _controller.ChangeHomeMemberPermissions(homeId, memberId, request);

        result.Should().NotBeNull();
        result.UserId.Should().Be(memberId);
        result.Permissions.Should().Contain(permissionAddDevice.Value.ToString());
        result.Permissions.Should().Contain(permissionListDevices.Value.ToString());
        _homeUserServiceMock.Verify(service => service.GetByIds(homeId, memberId), Times.Once);
        _homePermissionServiceMock.Verify(service => service.GetByValue(PermissionsGenerator.MemberCanAddDevice), Times.Once);
        _homePermissionServiceMock.Verify(service => service.GetByValue(PermissionsGenerator.MemberCanListDevices), Times.Once);
        _homeUserServiceMock.Verify(service => service.Update(It.IsAny<HomeUser>()), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void ChangeHomeMemberPermissions_WhenHomeUserNotFound_ShouldThrowNotFoundException()
    {
        // Arrange
        var homeId = "home123";
        var memberId = "member123";
        var request = new EditMemberPermissionsRequest { CanAddDevices = true, CanListDevices = true };

        _homeUserServiceMock.Setup(service => service.GetByIds(homeId, memberId)).Returns((HomeUser)null);

        _controller.ChangeHomeMemberPermissions(homeId, memberId, request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ChangeHomeMemberPermissions_WhenUserIsNotOwner_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var homeId = "home123";
        var memberId = "member123";
        var request = new EditMemberPermissionsRequest { CanAddDevices = true, CanListDevices = true };
        var home = new Home { Id = homeId, OwnerId = "owner123" };
        var found = new HomeUser { Home = home, UserId = memberId, Permissions = new List<HomePermission>() };
        var user = new User { Id = "notOwner123" };

        _homeUserServiceMock.Setup(service => service.GetByIds(homeId, memberId)).Returns(found);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        _controller.ChangeHomeMemberPermissions(homeId, memberId, request);
    }
}
