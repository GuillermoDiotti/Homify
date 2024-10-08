using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Session;
using Homify.WebApi.Controllers.Session.Models;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class SessionControllerTest
{
    private readonly SessionController _controller;
    private readonly Mock<ISessionService> _sessionServiceMock;
    private readonly Mock<IUserService> _userServiceMock;

    public SessionControllerTest()
    {
        _sessionServiceMock = new Mock<ISessionService>(MockBehavior.Strict);
        _userServiceMock = new Mock<IUserService>(MockBehavior.Strict);
        _controller = new SessionController(_sessionServiceMock.Object, _userServiceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void Create_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void Create_WhenEmailIsNull_ShouldThrowArgsNullException()
    {
        var request = new CreateSessionRequest
        {
            Email = null,
            Password = "testPassword"
        };

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void Create_WhenUserNotFound_ShouldThrowNotFoundException()
    {
        var request = new CreateSessionRequest
        {
            Email = "nonexistent@example.com",
            Password = "testPassword"
        };

        _userServiceMock.Setup(us => us.GetAll())
            .Returns([]);

        _controller.Create(request);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void Create_WhenEmailFormatIsInvalid_ShouldThrowInvalidFormatException()
    {
        var request = new CreateSessionRequest
        {
            Email = "invalid-email",
            Password = "testPassword"
        };

        _controller.Create(request);
    }

    [TestMethod]
    public void TestingResponse()
    {
        var id = "ala";
        var res = new CreateSessionResponse()
        {
            Token = "ala",
        };
        Assert.AreEqual(id, res.Token);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void Create_WhenPasswordIsIncorrect_ShouldThrowArgumentException()
    {
        var request = new CreateSessionRequest
        {
            Email = "user@example.com",
            Password = "wrongPassword"
        };

        var user = new User
        {
            Email = "user@example.com",
            Password = ".Coo120dshjha"
        };

        _userServiceMock.Setup(us => us.GetAll())
            .Returns([user]);

        _controller.Create(request);
    }

    [TestMethod]
    public void Create_WhenCredentialsAreCorrect_ShouldReturnCreateSessionResponse()
    {
        var request = new CreateSessionRequest
        {
            Email = "user@example.com",
            Password = ".Coo120dshjha"
        };

        var user = new User
        {
            Email = "user@example.com",
            Password = ".Coo120dshjha"
        };

        var session = new Session
        {
            AuthToken = Guid.NewGuid().ToString(),
            User = user
        };

        _userServiceMock.Setup(us => us.GetAll())
            .Returns([user]);

        _sessionServiceMock.Setup(ss => ss.CreateSession(It.IsAny<User>()))
            .Returns(session);

        var result = _controller.Create(request);

        result.Should().NotBeNull();
        result.Should().BeOfType<CreateSessionResponse>();
        result.Token.Should().Be(session.AuthToken);

        _sessionServiceMock.Verify(ss => ss.CreateSession(It.IsAny<User>()), Times.Once);
        _userServiceMock.Verify(us => us.GetAll(), Times.Once);
    }
}
