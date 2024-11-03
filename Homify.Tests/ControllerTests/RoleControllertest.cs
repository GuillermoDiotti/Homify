using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.WebApi;
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

    [TestMethod]
    public void AddRole_WhenUserLoggedIsNotNull_ReturnOk()
    {
        var roleService = new Mock<IRoleService>();
        var _controller = new RoleController(roleService.Object);
        var companyOwner = new CompanyOwner
        {
            Id = "1",
            IsIncomplete = true
        };
        var httpContext = new DefaultHttpContext();
        httpContext.Items[Items.UserLogged] = companyOwner;

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        var result = _controller.CreateRoleToExistingUser();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }
}
