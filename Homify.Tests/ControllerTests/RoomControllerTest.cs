using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Rooms;
using Homify.BusinessLogic.Rooms.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Rooms;
using Homify.WebApi.Controllers.Rooms.Models;
using Homify.WebApi.Controllers.Rooms.Models.Requests;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class RoomControllerTest
{
    private Mock<IRoomService>? _mockRoomService;
    private RoomController? _controller;

    [TestInitialize]
    public void Setup()
    {
        _mockRoomService = new Mock<IRoomService>();
        _controller = new RoomController(_mockRoomService.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void Create_NullRequest_ThrowsNullRequestException()
    {
        _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Create_NullHomeId_ThrowsArgumentNullException()
    {
        var request = new CreateRoomRequest
        {
            Name = "Living Room",
            HomeId = null
        };

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Create_NullHomeName_ThrowsArgumentNullException()
    {
        var request = new CreateRoomRequest
        {
            Name = null,
            HomeId = "id"
        };

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Create_NullOwner_ThrowsArgumentNullException()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = null;
        _controller.ControllerContext.HttpContext = httpContext;

        var request = new CreateRoomRequest
        {
            Name = "name",
            HomeId = "id"
        };

        _controller.Create(request);
    }

    [TestMethod]
    public void Create_ValidRequest_CallsRoomServiceAddHomeRoom()
    {
        var request = new CreateRoomRequest
        {
            Name = "Living Room",
            HomeId = "testHomeId"
        };
        var homeId = "testHomeId";

        var mockOwner = new HomeOwner()
        {
            Id = "ownerId"
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = mockOwner;
        _controller.ControllerContext.HttpContext = httpContext;

        _mockRoomService.Setup(s => s.AddHomeRoom(It.IsAny<CreateRoomArgs>()))
            .Returns(new Room { Id = "roomId" });

        var response = _controller.Create(request);

        _mockRoomService.Verify(s => s.AddHomeRoom(It.Is<CreateRoomArgs>(args =>
                args.Name == request.Name &&
                args.HomeId == homeId &&
                args.Owner == mockOwner)),
            Times.Once);
        Assert.AreEqual("roomId", response.Id);
    }

    [TestMethod]
    public void Create_ValidRequest_ReturnsCorrectRoomId()
    {
        var request = new CreateRoomRequest
        {
            Name = "Kitchen",
            HomeId = "home123"
        };
        var homeId = "home123";
        var room = new Room { Id = "room456" };

        var mockOwner = new HomeOwner()
        {
            Id = "ownerId"
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = mockOwner;
        _controller.ControllerContext.HttpContext = httpContext;

        _mockRoomService.Setup(s => s.AddHomeRoom(It.IsAny<CreateRoomArgs>())).Returns(room);

        var result = _controller.Create(request);

        Assert.AreEqual("room456", result.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AssignHomeDeviceToRoom_NullRoomId_ThrowsNullRequestException()
    {
        _controller.AssignHomeDeviceToRoom(null, "homeDeviceId");
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AssignHomeDeviceToRoom_NullOwnerId_ThrowsNullRequestException()
    {
        _controller.AssignHomeDeviceToRoom("123", "homeDeviceId");
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AssignHomeDeviceToRoom_NullHomeDeviceId_ThrowsNullRequestException()
    {
        _controller.AssignHomeDeviceToRoom("123", null);
    }

    [TestMethod]
    public void AssignHomeDeviceToRoom_ValidRequest_CallsRoomServiceAssignHomeDeviceToRoom()
    {
        var roomId = "testRoomId";
        var homeDeviceId = "testHomeDeviceId";
        var mockOwner = new HomeOwner()
        {
            Id = "ownerId"
        };

        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = mockOwner;
        _controller.ControllerContext.HttpContext = httpContext;

        _mockRoomService.Setup(s => s.AssignHomeDeviceToRoom(It.IsAny<UpdateRoomArgs>()))
            .Returns(new Room { Id = roomId });

        var result = _controller.AssignHomeDeviceToRoom(roomId, homeDeviceId);

        _mockRoomService.Verify(s => s.AssignHomeDeviceToRoom(It.Is<UpdateRoomArgs>(args =>
            args.RoomId == roomId &&
            args.HomeDeviceId == homeDeviceId &&
            args.Owner == mockOwner)), Times.Once);
        Assert.AreEqual(roomId, result.Id);
    }

    [TestMethod]
    public void ObtainHomeRooms_ShouldReturnListOfRoomBasicInfo()
    {
        var homeId = "home123";
        var rooms = new List<Room>
        {
            new Room { Id = "1", Name = "Living Room" },
            new Room { Id = "2", Name = "Bedroom" }
        };

        _mockRoomService.Setup(service => service.GetAllRoomsOfHouse(homeId)).Returns(rooms);

        var result = _controller.ObtainHomeRooms(homeId) as List<RoomBasicInfo>;

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Living Room", result[0].Name);
        Assert.AreEqual("Bedroom", result[1].Name);

        _mockRoomService.Verify(service => service.GetAllRoomsOfHouse(homeId), Times.Once);
    }
}
