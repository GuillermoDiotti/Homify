using System.Linq;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes;
using Homify.BusinessLogic.Homes.Entities;
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

        var response = _controller.Create(request);

        Assert.IsNotNull(response);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateMemberList_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.UpdateMembersList(null);
    }

    [TestMethod]
    public void UpdateMemberList_WhenRequestIsOk_ShouldUpdateList()
    {
        var request = new UpdateMemberListRequest
        {
            Email = "test@example.com"
        };

        var existingMember = new User { Id = "123", Name = "Existing Member", Email = "mail1" };
        var newMember = new User { Id = "456", Name = "New Member", Email = "test@example.com" };

        var homeResponseBeforeUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Members = new List<User> { existingMember }
        };

        var homeResponseAfterUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Members = new List<User> { existingMember, newMember }
        };

        _homeServiceMock.Setup(service => service.UpdateMemberList(request.Email))
                        .Returns(homeResponseAfterUpdate);

        var result = _controller.UpdateMembersList(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(homeResponseAfterUpdate.Members, result.Members);

        Assert.AreEqual(2, result.Members.Count, "La cantidad de miembros debería haber aumentado a 2");

        Assert.IsTrue(result.Members.Contains(newMember), "El nuevo miembro debería estar en la lista");
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateHomeDevices_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.UpdateHomeDevice(null);
    }

    [TestMethod]
    public void UpdateHomeDevice_WhenRequestIsValid_ShouldIncreaseDeviceCount()
    {
        var request = new UpdateHomeDevicesRequest
        {
            DeviceId = "device123"
        };

        var device = new Device()
        {
            Id = "device123"
        };

        var homeBeforeUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Devices = new List<Device>()
        };

        var homeAfterUpdate = new Home
        {
            Id = "1",
            Street = "Test Home",
            Devices = new List<Device> { device }
        };

        _homeServiceMock.Setup(service => service.UpdateHomeDevices(request.DeviceId))
                        .Callback(() => homeBeforeUpdate.Devices.Add(device));

        _controller.UpdateHomeDevice(request);

        Assert.AreEqual(1, homeBeforeUpdate.Devices.Count, "La cantidad de dispositivos debería haber aumentado a 1");

        Assert.IsTrue(homeBeforeUpdate.Devices.Contains(device), "El nuevo dispositivo debería estar en la lista");
    }

    [TestMethod]
    public void GetMembers_WhenCalled_ShouldReturnListOfHomeMembers()
    {
        var membersList = new List<User>
        {
        new User { Id = "1", Name = "John Doe", Email = "john@example.com" },
        new User { Id = "2", Name = "Jane Smith", Email = "jane@example.com" }
        };

        _homeServiceMock.Setup(service => service.GetHomeMembers())
                        .Returns(membersList);

        var result = _controller.GetMembers();

        Assert.IsNotNull(result, "El resultado no debe ser nulo");
        Assert.AreEqual(2, result.Count, "La lista debe contener 2 miembros");

        Assert.AreEqual("John Doe", result[0].Members[0].Name);
        Assert.AreEqual("jane@example.com", result[1].Members[0].Email);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void UpdateNotificatorsList_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.NofificatedMembers(null);
    }
}
