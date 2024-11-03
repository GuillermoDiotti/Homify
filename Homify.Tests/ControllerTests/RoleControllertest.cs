using Homify.BusinessLogic.Roles;
using Homify.WebApi.Controllers.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class RoleControllertest
{
    [TestMethod]
    public void AddRole_WhenUserLoggedIsNull_ReturnUnauthorized()
    {
        var roleService = new Mock<IRoleService>();
        var controller = new RoleController(roleService.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
        };

        var result = controller.CreateRoleToExistingUser();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
    }
}
