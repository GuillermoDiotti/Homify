using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
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

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public void AssignRoleToExistingUser_UserWithoutRequiredRole_ThrowsInvalidOperationException()
    {
        var user = new User
        {
            Id = "1",
            Name = "Carlos",
            Roles =
            [
                new UserRole { Role = RolesGenerator.HomeOwner() }
            ],
        };

        var mockHttpContext = new DefaultHttpContext();
        mockHttpContext.Items[Items.UserLogged] = user;

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
