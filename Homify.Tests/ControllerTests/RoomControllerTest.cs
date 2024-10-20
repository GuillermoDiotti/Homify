using Homify.BusinessLogic.HomeOwners;
using Homify.DataAccess.Repositories.Rooms;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Rooms;
using Homify.WebApi.Controllers.Rooms.Models;
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
        _controller.Create(null, "homeId");
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Create_NullHomeId_ThrowsArgumentNullException()
    {
        var request = new CreateRoomRequest
        {
            Name = "Living Room"
        };

        _controller.Create(request, null);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Create_NullHomeName_ThrowsArgumentNullException()
    {
        var request = new CreateRoomRequest
        {
            Name = null
        };

        _controller.Create(request, "id");
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
            Name = "name"
        };

        _controller.Create(request, "id");
    }

    [TestMethod]
    public void Create_ValidRequest_CallsRoomServiceAddHomeRoom()
    {
        var request = new CreateRoomRequest
        {
            Name = "Living Room"
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

        var response = _controller.Create(request, homeId);

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
            Name = "Kitchen"
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

        var result = _controller.Create(request, homeId);

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
}
