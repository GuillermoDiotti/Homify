using System.Net;
using FluentAssertions;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;

namespace Homify.Tests.FilterTests;

[TestClass]
public class AuthenticationFilterAttributeTest(
    Mock<HttpContext> httpContextMock,
    Mock<ISessionService> sessionServiceMock,
    AuthorizationFilterContext context)
{
    private readonly AuthenticationFilterAttribute _attribute = new();

    [TestMethod]
    public void Authenticate_WhenTokenIsCorrect_ShouldNotFail()
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
        sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns(user);

        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns(validToken);
        httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(sessionServiceMock.Object);
        httpContextMock.SetupSet(h => h.Items[Items.UserLogged] = user);
        _attribute.OnAuthorization(context);

        IActionResult? response = context.Result;

        httpContextMock.VerifyAll();
        sessionServiceMock.VerifyAll();
        response.Should().BeNull();
    }

    [TestMethod]
    public void Authenticate_WhenGetUserByTokenThrowsNotFoundException_ShouldThrow401()
    {
        var authorizationHeader = "Authorization";
        var validToken = Guid.NewGuid().ToString();

        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns(validToken);
        sessionServiceMock
            .Setup(sessionService => sessionService.GetUserByToken(validToken))
            .Throws(new NotFoundException("Not found"));
        httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(sessionServiceMock.Object);

        _attribute.OnAuthorization(context);

        var response = context.Result;
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
    }

    [TestMethod]
    public void Authenticate_WhenAuthorizationHeaderIsNull_ShouldThrow401()
    {
        var authorizationHeader = "Authorization";

        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns((string)null);

        _attribute.OnAuthorization(context);

        var response = context.Result;
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
    }

    [TestMethod]
    public void Authenticate_WhenTokenIsMissing_ShouldThrow401()
    {
        var authorizationHeader = "Authorization";
        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns(string.Empty);

        _attribute.OnAuthorization(context);
        var response = context.Result;
        httpContextMock.VerifyAll();
        sessionServiceMock.VerifyAll();
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
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
        var authorizationHeader = "Authorization";
        var validToken = Guid.NewGuid().ToString();

        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns(validToken);
        sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns((User?)null);
        httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>()))
            .Returns(sessionServiceMock.Object);
        httpContextMock.SetupSet(h => h.Items[Items.UserLogged] = (User?)null);

        _attribute.OnAuthorization(context);
        var response = context.Result;
        httpContextMock.VerifyAll();
        sessionServiceMock.VerifyAll();
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
    }

    [TestMethod]
    public void Authenticate_WhenAuthorizationHeaderIsMissing_ShouldThrow401()
    {
        httpContextMock.Setup(h => h.Request.Headers[It.IsAny<string>()]).Returns((string)null);

        _attribute.OnAuthorization(context);

        var response = context.Result;
        response.Should().NotBeNull();
        var concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
    }

    [TestMethod]
    public void Authenticate_WhenUserIsAuthenticated_ShouldSetUserInHttpContextItems()
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

        sessionServiceMock.Setup(sessionService => sessionService.GetUserByToken(validToken)).Returns(user);
        httpContextMock.Setup(h => h.Request.Headers[authorizationHeader]).Returns(validToken);
        httpContextMock.Setup(h => h.RequestServices.GetService(It.IsAny<Type>())).Returns(sessionServiceMock.Object);

        _attribute.OnAuthorization(context);

        httpContextMock.VerifySet(h => h.Items[Items.UserLogged] = user, Times.Once);
        httpContextMock.VerifyAll();
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
