using System.Net;
using FluentAssertions;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.SystemPermissions;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;
using Homify.WebApi;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Moq;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

namespace Homify.Tests.FilterTests;

[TestClass]
public class AuthorizationFilterAttributeTest
{
    private readonly Mock<HttpContext> _httpContextMock;
    private readonly Mock<ISessionService> _sessionServiceMock;
    private readonly AuthorizationFilterContext _context;
    private AuthorizationFilter _attribute = null!;

    private readonly SystemPermission _permission;
    private readonly Role _roleForTest;
    private readonly User _user;
    private readonly string _validToken;
    private readonly string _authorizationHeader;

    public AuthorizationFilterAttributeTest()
    {
        _httpContextMock = new Mock<HttpContext>(MockBehavior.Loose);
        _sessionServiceMock = new Mock<ISessionService>(MockBehavior.Loose);
        _context = new AuthorizationFilterContext(
            new ActionContext(
                _httpContextMock.Object,
                new RouteData(),
                new ActionDescriptor()),
            new List<IFilterMetadata>());

        _permission = new SystemPermission { Value = "admins-Create" };

        _roleForTest = new Role { Name = Constants.ADMINISTRATOR, Permissions = [_permission] };

        _authorizationHeader = "Authorization";
        _validToken = Guid.NewGuid().ToString();
        _user = new User
        {
            Name = "Hola",
            LastName = "ADA",
            Email = "ada@email.com",
            Password = "adaPASS",
            Role = _roleForTest
        };

        _sessionServiceMock.Setup(sessionService =>
            sessionService.GetUserByToken(_validToken)).Returns(_user);
        _httpContextMock.Setup(h => h.Request.Headers[_authorizationHeader]).Returns(_validToken);
        _httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(_sessionServiceMock.Object);
        _httpContextMock.SetupSet(h => h.Items[Items.UserLogged] = _user);
        _httpContextMock.Setup(h => h.Items[Items.UserLogged]).Returns(_user);
        _attribute = new AuthorizationFilter("admins-Create");
    }

    [TestMethod]
    public void Authenticate_WhenTokenIsCorrect_ShouldAuthenticate()
    {
        var authorizationHeader = "Authorization";
        var validToken = Guid.NewGuid().ToString();
        var user = new User
        {
            Name = "BBB",
            LastName = "AAA",
            Email = "BB@email.com",
            Password = "bbPASS",
        };

        _sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns(user);

        _httpContextMock.Setup(h => h.Request.Headers.TryGetValue(authorizationHeader, out It.Ref<StringValues>.IsAny))
            .Returns((string key, out StringValues value) =>
            {
                value = new StringValues(validToken);
                return true;
            });

        _httpContextMock.Setup(h => h.RequestServices.GetService(typeof(ISessionService)))
            .Returns(_sessionServiceMock.Object);

        _attribute.OnAuthorization(_context);

        IActionResult? response = _context.Result;
        response.Should().BeNull();
    }

    [TestMethod]
    public void Authorization_WhenNoPermission_ShouldFail()
    {
        _user.Role.Permissions.Clear();

        _attribute = new AuthorizationFilter("admins-Create");
        _attribute.OnAuthorization(_context);

        var response = _context.Result;
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Forbidden);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthorized");
            GetMessage(concreteResponse.Value).Should().Be("You are not authorized");
        }
    }

    private string GetInnerCode(object value)
    {
        return value.GetType().GetProperty("InnerCode").GetValue(value).ToString();
    }

    private string GetMessage(object value)
    {
        return value.GetType().GetProperty("Message").GetValue(value).ToString();
    }
}
