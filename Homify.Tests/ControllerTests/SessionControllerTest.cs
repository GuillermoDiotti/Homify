using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.WebApi.Controllers.Session;
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
    [ExpectedException(typeof(Exception))]
    public void Create_WhenRequestIsNull_ShouldThrowException()
    {
        _controller.Create(null);
    }
}
