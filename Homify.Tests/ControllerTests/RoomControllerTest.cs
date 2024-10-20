using Homify.DataAccess.Repositories.Rooms;
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
}
