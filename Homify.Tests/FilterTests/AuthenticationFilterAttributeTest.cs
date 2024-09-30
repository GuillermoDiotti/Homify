using System.Net;
using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Homify.WebApi;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;

namespace Homify.Tests.FilterTests;

[TestClass]
public class AuthenticationFilterAttributeTest
{
    private Mock<HttpContext> _httpContextMock;
    private Mock<ISessionService> _sessionServiceMock;
    private AuthorizationFilterContext _context;
    private AuthenticationFilterAttribute _attribute;

    public AuthenticationFilterAttributeTest(Mock<HttpContext> httpContextMock, Mock<ISessionService> sessionServiceMock, AuthorizationFilterContext context)
    {
        _httpContextMock = httpContextMock;
        _sessionServiceMock = sessionServiceMock;
        _context = context;
        _attribute = new AuthenticationFilterAttribute();
    }

    [TestMethod]
    public void Authenticate_WhenTokenIsCorrect_ShouldNotFail()
    {
        var AUTHORIZATION_HEADER = "Authorization";
        var validToken = Guid.NewGuid().ToString();
        User user = new User
        {
            Name = "BBB",
            LastName = "AAA",
            Email = "BB@email.com",
            Password = "bbPASS",
        };
        _sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns(user);

        _httpContextMock.Setup(h => h.Request.Headers[AUTHORIZATION_HEADER]).Returns(validToken);
        _httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(_sessionServiceMock.Object);
        _httpContextMock.SetupSet(h => h.Items[Items.UserLogged] = user);
        _attribute.OnAuthorization(_context);

        IActionResult? response = _context.Result;

        _httpContextMock.VerifyAll();
        _sessionServiceMock.VerifyAll();
        response.Should().BeNull();
    }

    [TestMethod]
    public void Authenticate_WhenTokenIsMissing_ShouldThrow401()
    {
        var AUTHORIZATION_HEADER = "Authorization";
        _httpContextMock.Setup(h => h.Request.Headers[AUTHORIZATION_HEADER]).Returns(String.Empty);

        _attribute.OnAuthorization(_context);
        IActionResult? response = _context.Result;
        _httpContextMock.VerifyAll();
        _sessionServiceMock.VerifyAll();
        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
    }

    [TestMethod]
    public void Authenticate_WhenTokenIsNotAssignedToAUser_ShouldThrow401()
    {
        var AUTHORIZATION_HEADER = "Authorization";
        var validToken = Guid.NewGuid().ToString();

        _httpContextMock.Setup(h => h.Request.Headers[AUTHORIZATION_HEADER]).Returns(validToken);
        _sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns((User?)null);
        _httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(_sessionServiceMock.Object);
        _httpContextMock.SetupSet(h => h.Items[Items.UserLogged] = (User?)null);

        _attribute.OnAuthorization(_context);
        IActionResult? response = _context.Result;
        _httpContextMock.VerifyAll();
        _sessionServiceMock.VerifyAll();
        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
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
