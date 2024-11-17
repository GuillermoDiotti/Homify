using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Session;
using Homify.WebApi.Controllers.Session.Models.Requests;
using Homify.WebApi.Controllers.Session.Models.Responses;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class SessionControllerTest
{
    private readonly SessionController _controller;
    private readonly Mock<ISessionService> _sessionServiceMock;

    public SessionControllerTest()
    {
        _sessionServiceMock = new Mock<ISessionService>(MockBehavior.Strict);
        _controller = new SessionController(_sessionServiceMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(NullRequestException))]
    public void Create_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.Create(null);
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

        _sessionServiceMock.Setup(s => s.CheckSessionConstraints(It.IsAny<string?>(), It.IsAny<string?>()))
            .Returns(user);

        _sessionServiceMock.Setup(ss => ss.CreateSession(It.IsAny<User>()))
            .Returns(session);

        var result = _controller.Create(request);

        result.Should().NotBeNull();
        result.Should().BeOfType<CreateSessionResponse>();
        result.Token.Should().Be(session.AuthToken);

        _sessionServiceMock.Verify(ss => ss.CreateSession(It.IsAny<User>()), Times.Once);
    }
}
