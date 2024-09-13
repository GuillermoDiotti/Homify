using Homify.Exceptions;
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
    [ExpectedException(typeof(NullRequestException))]
    public void CreateAdmin_WhenRequestIsNull_ShouldThrowEception()
    {
        var admin = _controller.Create(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CreateAdmin_WhenNameIsNull_ShouldThrowExceptionn()
    {
        var request = new CreateAdminRequest()
        {
            Name = null, Email = "example@gmail.com", Password = "password", LastName = "Doe"
        };
        _controller.Create(request);
    }
    #endregion
}
