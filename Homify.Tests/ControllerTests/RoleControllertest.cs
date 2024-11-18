using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Controllers.Notifications;
using Homify.WebApi.Controllers.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Homify.Tests.ControllerTests;

[TestClass]
public class RoleControllertest
{
    private readonly Mock<IRoleService> mockRoleService;
    private readonly Mock<IUserService>? _mockUserService;
    public RoleControllertest()
    {
        mockRoleService = new Mock<IRoleService>();
        _mockUserService = new Mock<IUserService>();
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AssignRoleToExistingUser_UserNotFound_ThrowsNotFoundException()
    {
        var userId = "testUserId";
        var user = new User { Id = userId };
        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = null;

        var mockController = new RoleController(mockRoleService.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            }
        };

        mockController.AssignRoleToExistingUser();
    }
}
