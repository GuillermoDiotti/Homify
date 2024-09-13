using Homify.WebApi.Controllers.Admins;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class AdminControllerTests
{
    private AdminController _controller;

    public AdminControllerTests()
    {
        _controller = new AdminController();
    }

    #region Create
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void CreateAdmin_WhenRequestIsNull_ShouldThrowEception()
    {
        var admin = _controller.Create(null);
    }
    #endregion
}
