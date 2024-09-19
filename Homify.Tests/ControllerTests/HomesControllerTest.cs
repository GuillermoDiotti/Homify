using Homify.BusinessLogic.Homes;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Homes;
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
}
