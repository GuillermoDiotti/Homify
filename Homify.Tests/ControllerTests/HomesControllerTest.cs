﻿using FluentAssertions;
using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.BusinessLogic.Permissions.HomePermissions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Controllers.Homes;
using Homify.WebApi.Controllers.Homes.Models.Requests;
using Homify.WebApi.Controllers.Homes.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.Tests.ControllerTests;
[TestClass]
public class HomesControllerTest
{
    private readonly HomeController? _controller;
    private readonly Mock<IHomeService>? _homeServiceMock;
    private readonly Mock<IHomeUserService> _homeUserServiceMock;
    private readonly Mock<IHomePermissionService> _homePermissionServiceMock;
    public HomesControllerTest()
    {
        _homeServiceMock = new Mock<IHomeService>(MockBehavior.Strict);
        _homeUserServiceMock = new Mock<IHomeUserService>(MockBehavior.Strict);
        _homePermissionServiceMock = new Mock<IHomePermissionService>(MockBehavior.Strict);
        _controller = new HomeController(_homeServiceMock.Object, _homeUserServiceMock.Object, _homePermissionServiceMock.Object);
    }

    [TestMethod]
    public void GetHomeAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var home = new Home()
        {
            Id = "home123",
            Alias = "Home 1",
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
        home.Alias.Should().Be("Home 1");
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
            Alias = "Home 1",
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
            Alias = "Home 1",
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
            Alias = "Home 1",
            Number = "3",
            Latitude = null
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles =
            [
                new UserRole
                {
                    UserId = "adminId",
                    RoleId = Constants.ADMINISTRATORID,
                    Role = RolesGenerator.HomeOwner()
                }

            ]
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;

        _controller.ControllerContext.HttpContext = httpContext;

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenLongitudIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = "3",
            Alias = "Home 1",
            Latitude = "141",
            Longitud = null
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles =
            [
                new UserRole
                {
                    UserId = "adminId",
                    RoleId = Constants.ADMINISTRATORID,
                    Role = RolesGenerator.HomeOwner()
                }

            ]
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.Create(request);
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
            Alias = "Home 1",
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
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenAliasIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = "3",
            Latitude = "141",
            Longitud = "231",
            Alias = null,
            MaxMembers = 1
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles =
            [
                new UserRole
                {
                    UserId = "adminId",
                    RoleId = Constants.ADMINISTRATORID,
                    Role = RolesGenerator.HomeOwner()
                }

            ]
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;

        _controller.ControllerContext.HttpContext = httpContext;

        _controller.Create(request);
    }

    [TestMethod]
    public void Create_WithValidRequest_ShouldReturnCreateHomeResponse()
    {
        var request = new CreateHomeRequest
        {
            Street = "calle 1",
            Number = "1",
            Latitude = "101",
            Longitud = "202",
            MaxMembers = 3,
            Alias = "Home 1"
        };

        var owner = new HomeOwner
        {
            Id = "Owner123",
            Name = "John Doe",
            Roles =
            [
                new UserRole
                {
                    UserId = "adminId",
                    RoleId = Constants.ADMINISTRATORID,
                    Role = RolesGenerator.HomeOwner()
                }

            ]
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = owner;

        _controller.ControllerContext.HttpContext = httpContext;

        var expectedHome = new Home("calle 1", "1", "101", "202", 3, owner, [], []);

        _homeServiceMock.Setup(service => service.Add(It.IsAny<CreateHomeArgs>()))
            .Returns(expectedHome);

        var response = _controller.Create(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(expectedHome.Id, response.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevices_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.AssignDeviceToHome(null, "home123");
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

        _homeServiceMock.Setup(service => service.AssignDevice(request.DeviceId, "home1", user)).Returns(updatedDevice);

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        var result = _controller.AssignDeviceToHome(request, "home1");

        _homeServiceMock.Verify(service => service.AssignDevice(request.DeviceId, "home1", user), Times.Once);
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

        var result = _controller.AllHomeDevices(homeId, null);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateNotificatorsList_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.UpdateNotificatedMembers("homeIe", null);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeAlias_WhenRequestIsNulll_ShouldThrowEsception()
    {
        _controller.UpdateHome(null, null);
    }

    [TestMethod]
    public void UpdateHomeAlias_WhenRequestIsValid_ShouldReturnUpdatedAlias()
    {
        var user = new HomeOwner()
        {
            Id = "user123",
            Name = "John Doe"
        };

        var home = new Home
        {
            Id = "home123",
            Alias = "Home 1",
            Owner = user
        };

        var updatedHome = new Home
        {
            Id = "home123",
            Alias = "updatedAlias",
            Owner = user
        };

        var req = new UpdateHomeRequest() { Alias = "updatedAlias" };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _homeServiceMock.Setup(service => service.Update(home.Id, "updatedAlias", user)).Returns(updatedHome);

        _controller.UpdateHome("home123", req);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UpdateHomeAlias_WhenAliasIsNull_ShouldThrowException()
    {
        var user = new HomeOwner()
        {
            Id = "user123",
            Name = "John Doe"
        };

        var home = new Home
        {
            Id = "home123",
            Alias = "Home 1",
            Owner = user
        };

        var req = new UpdateHomeRequest() { Alias = null };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _homeServiceMock.Setup(service => service.Update(home.Id, null, user)).Throws(new ArgumentNullException("Alias can not be null"));

        _controller.UpdateHome("home123", req);
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

        var result = _controller.UpdateNotificatedMembers(homeId, request);

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

        _homeServiceMock.Setup(service => service.GetMembers(homeId, user)).Throws(new NotFoundException("Home not found"));

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

        _homeServiceMock.Setup(service => service.GetMembers(homeId, user)).Throws(new InvalidOperationException("Only the owner can see the members"));

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = user;
        _controller.ControllerContext.HttpContext = httpContext;

        _controller.ObtainMembers(homeId);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateMembersList_WhenRequestIsNull_ShouldThrowNullRequestException()
    {
        _controller.AddMemberToHome("home123", null);
    }

    [TestMethod]
    public void ObtainMembers_WhenHomeIdIsValid_ShouldReturnMembersList()
    {
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

        _homeServiceMock.Setup(service => service.GetMembers(homeId, user)).Returns(homeMembers);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var result = _controller.ObtainMembers(homeId);

        result.Should().NotBeNull();
        result.Count.Should().Be(2);
        result[0].Should().BeEquivalentTo(new GetMemberResponse(homeMembers[0]));
        result[1].Should().BeEquivalentTo(new GetMemberResponse(homeMembers[1]));
        _homeServiceMock.Verify(service => service.GetMembers(homeId, user), Times.Once);
    }

    [TestMethod]
    public void ChangeHomeMemberPermissions_WhenRequestIsValid_ShouldReturnHomeMemberBasicInfo()
    {
        var homeId = "home123";
        var memberId = "member123";
        var request = new EditMemberPermissionsRequest
        {
            CanAddDevices = true,
            CanListDevices = true,
            CanRenameDevices = false
        };
        var user = new User { Id = "owner123" };
        var home = new Home { Id = homeId, OwnerId = "owner123" };
        var found = new HomeUser { Home = home, UserId = memberId, Permissions = [] };
        var permissionAddDevice = new HomePermission { Value = PermissionsGenerator.MemberCanAddDevice };
        var permissionListDevices = new HomePermission { Value = PermissionsGenerator.MemberCanListDevices };
        var permissionsList = new List<HomePermission> { permissionAddDevice, permissionListDevices };

        _homeUserServiceMock.Setup(service => service.Get(homeId, memberId)).Returns(found);

        _homePermissionServiceMock.Setup(service => service.ChangeHomeMemberPermissions(request.CanAddDevices, request.CanListDevices, request.CanRenameDevices, user, found)).Returns(permissionsList);
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
        _homeUserServiceMock.Verify(service => service.Get(homeId, memberId), Times.Once);
        _homeUserServiceMock.Verify(service => service.Update(It.IsAny<HomeUser>()), Times.Once);
    }

    [TestMethod]
    public void GetHomes_WhenUserIsOk_ShouldReturnHomes()
    {
        var user = new User { Id = "user1" };
        var homes = new List<Home> { new Home { Id = "home1" }, new Home { Id = "home2" } };
        _homeServiceMock.Setup(service => service.GetAllWhereUserIsOwner(user)).Returns(homes);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var result = _controller.ObtainHomesWhereUserIsOwner();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void GetHomes_WhenUserIsOk_ShouldReturnHomes2()
    {
        var user = new User { Id = "user1" };
        var hu1 = new HomeUser()
        {
            UserId = "user1"
        };
        var homes = new List<Home> { new Home { Id = "home1", Members = [hu1] } };
        _homeServiceMock.Setup(service => service.GetAllWhereUserIsMember(user)).Returns(homes);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        _controller.ControllerContext.HttpContext.Items[Items.UserLogged] = user;

        var result = _controller.ObtainHomesWhereUserIsMember();

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }
}
