using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Session;
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
}
