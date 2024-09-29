using FluentAssertions;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Homes;
using Homify.WebApi.Controllers.Homes.Models;
using Moq;

namespace Homify.Tests.ControllerTests;
[TestClass]
public class HomesControllerTest
{
    private readonly HomeController? _controller;
    private readonly Mock<IHomeService>? _homeServiceMock;
    public HomesControllerTest()
    {
        _homeServiceMock = new Mock<IHomeService>(MockBehavior.Strict);
        _controller = new HomeController(_homeServiceMock.Object);
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
            MaxMembers = "3",
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
        home.MaxMembers.Should().Be("3");
        home.Owner.Name.Should().Be("Owner Name");
        home.Devices.Should().BeEmpty();
    }

    [TestMethod]
    public void GetHomePermissionAttributes_WhenCalled_ShouldReturnAttributes()
    {
        var homepermission = new HomePermission()
        {
            Id = 123,
            Value = "calle 1"
        };

        homepermission.Id.Should().Be(123);
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
            HardwareId = 1001
        };

        homedevice.HomeId.Should().Be("home123");
        homedevice.DeviceId.Should().Be("device123");
        homedevice.Home.Id.Should().Be("home123");
        homedevice.Device.Id.Should().Be("device123");
        homedevice.Connected.Should().BeTrue();
        homedevice.HardwareId.Should().Be(1001);
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
        HomePermission permission = new HomePermission()
        {
            Id = 123,
            Value = "calle 1",
            HomeUser = homeuser,
            HomeId = "home123",
            UserId = "device123"
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
        homeuser.HomeId.Should().BeSameAs(permission.HomeId);
        homeuser.UserId.Should().BeSameAs(permission.UserId);
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
            Street = null
        };
        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateHome_WhenNumberIsNull_ShouldThrowException()
    {
        var request = new CreateHomeRequest()
        {
            Street = "calle",
            Number = null
        };
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
            Latitude = "141",
            Longitud = null
        };
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
            MaxMembers = null
        };
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
            MaxMembers = "3"
        };

        var expectedHome = new Home("calle 1", "1", "101", "202", "3", new HomeOwner(), new List<HomeDevice>(), new List<HomeUser>());

        _homeServiceMock.Setup(service => service.AddHome(It.IsAny<CreateHomeArgs>()))
                        .Returns(expectedHome);

        var response = _controller.Create(request);

        Assert.IsNotNull(response, "La respuesta no debería ser null");
        Assert.AreEqual(expectedHome.Id, response.Id, "El ID del hogar devuelto no es el esperado");
    }

    [TestMethod]
    public void UpdateMemberList_WhenRequestIsOk_ShouldUpdateNotificatedMembersList()
    {
        var request = new UpdateMemberListRequest
        {
            Email = "test@example.com"
        };

        var existingMember = new HomeUser
        {
            HomeId = "123",
            UserId = "1",
            User = new User
            {
                Name = "Existing Member",
                Email = "mail1"
            }
        };

        var newMember = new HomeUser
        {
            HomeId = "456",
            UserId = "2",
            User = new User
            {
                Name = "New Member",
                Email = "test@example.com"
            }
        };

        var homeResponseBeforeUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Number = "1234",
            Latitude = "0.0000",
            Longitude = "0.0000",
            MaxMembers = "5",
            Owner = new HomeOwner
            {
                Name = "Owner Name",
                Role = RolesGenerator.HomeOwner()
            },
            Devices = [],
            NofificatedMembers = [existingMember],
        };

        var homeResponseAfterUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Number = "1234",
            Latitude = "0.0000",
            Longitude = "0.0000",
            MaxMembers = "5",
            Owner = new HomeOwner
            {
                Id = "1",
                Name = "Owner Name"
            },
            Devices = [],
            NofificatedMembers = [existingMember, newMember],
            OwnerId = "1"
        };

        _homeServiceMock.Setup(service => service.UpdateMemberList(homeResponseAfterUpdate.Id, request.Email))
                        .Returns(homeResponseAfterUpdate);

        var result = _controller.UpdateMembersList("1", request);

        Assert.IsNotNull(result);
        homeResponseAfterUpdate.OwnerId.Should().Be(homeResponseAfterUpdate.Owner.Id);
        Assert.AreEqual(2, result.Members.Count, "La cantidad de miembros notificados debería haber aumentado a 2");
        Assert.IsTrue(result.Members.Any(m => m.User.Email == "test@example.com"), "El nuevo miembro debería estar en la lista de miembros notificados");
        Assert.AreEqual(homeResponseAfterUpdate.NofificatedMembers, result.Members, "La lista de miembros notificados debería coincidir con la respuesta esperada");
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

        var homeDevice = new HomeDevice
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
            HardwareId = 1001
        };

        _homeServiceMock.Setup(service => service.UpdateHomeDevices(request.DeviceId, homeDevice.HomeId)).Verifiable();

        _controller.UpdateHomeDevice(request, "home1");

        _homeServiceMock.Verify(service => service.UpdateHomeDevices(request.DeviceId, homeDevice.HomeId), Times.Once,
            "El servicio debería ser llamado exactamente una vez con el DeviceId correcto.");
    }

    [TestMethod]
    public void GetMembers_WhenCalled_ShouldReturnListOfHomeMembers()
    {
        var membersList = new List<User>
        {
        new User
        {
            Id = "1",
            Name = "John Doe",
            Email = "john@example.com"
        },
        new User
        {
            Id = "2",
            Name = "Jane Smith",
            Email = "jane@example.com"
        }
        };

        _homeServiceMock.Setup(service => service.GetHomeMembers("home123")).Returns(membersList);

        var result = _controller.ObtainMembers("home123");

        Assert.IsNotNull(result, "El resultado no debe ser nulo");
        Assert.AreEqual(2, result.Count, "La lista debe contener 2 miembros");

        Assert.AreEqual("John Doe", result[0].Members[0].Name);
        Assert.AreEqual("jane@example.com", result[1].Members[0].Email);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateNotificatorsList_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.NotificatedMembers("homeIe", null);
    }

    [TestMethod]
    public void UpdateNofificatedMembers_WhenRequestIsValid_ShouldUpdate()
    {
        var request = new NotificatedMembersRequest
        {
            MemberId = "member123"
        };

        _homeServiceMock.Setup(service => service.UpdateNotificatedList("homeId", request.MemberId)).Verifiable();

        _controller.NotificatedMembers("homeId", request);

        _homeServiceMock.Verify(service => service.UpdateNotificatedList("homeId", request.MemberId), Times.Once,
            "El servicio debería ser llamado exactamente una vez con el MemberId correcto.");
    }

    [TestMethod]
    public void GetHomeDevices_WhenCalled_ShouldReturnListOfDevices()
    {
        var devices = new List<Device>
    {
        new Device
        {
            Name = "Device 1",
            Model = "Model A",
            IsActive = true,
            Photos = ["photo1.jpg"]
        },
        new Device
        {
            Name = "Device 2",
            Model = "Model B",
            IsActive = false,
            Photos = ["photo2.jpg"]
        }
    };

        _homeServiceMock.Setup(service => service.GetHomeDevices("homeId")).Returns(devices);

        var result = _controller.ObtainHomeDevices("homeId");

        Assert.IsNotNull(result, "El resultado no debería ser null.");
        Assert.AreEqual(2, result.Count, "Debería haber 2 dispositivos en la lista.");

        Assert.AreEqual("Device 1", result[0].Name, "El nombre del primer dispositivo no es el esperado.");
        Assert.AreEqual("Model A", result[0].Model, "El modelo del primer dispositivo no es el esperado.");
        Assert.IsTrue(result[0].IsConnected, "El primer dispositivo debería estar conectado.");
        Assert.AreEqual("photo1.jpg", result[0].MainPhoto, "La foto principal del primer dispositivo no es la esperada.");

        Assert.AreEqual("Device 2", result[1].Name, "El nombre del segundo dispositivo no es el esperado.");
        Assert.AreEqual("Model B", result[1].Model, "El modelo del segundo dispositivo no es el esperado.");
        Assert.IsFalse(result[1].IsConnected, "El segundo dispositivo no debería estar conectado.");
        Assert.AreEqual("photo2.jpg", result[1].MainPhoto, "La foto principal del segundo dispositivo no es la esperada.");
    }
}
