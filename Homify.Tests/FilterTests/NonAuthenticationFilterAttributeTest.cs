using System.Net;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;

namespace Homify.Tests.FilterTests;

public class NonAuthenticationFilterAttributeTest
{
    [TestClass]
    public class NonAuthenticationFilterTests
    {
        private Mock<ISessionService> _sessionServiceMock;
        private NonAuthenticationFilter _filter;
        private ActionExecutingContext _actionExecutingContext;

        public NonAuthenticationFilterTests()
        {
            _sessionServiceMock = new Mock<ISessionService>();
            _filter = new NonAuthenticationFilter();

            var httpContext = new DefaultHttpContext();
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(ISessionService))).Returns(_sessionServiceMock.Object);
            httpContext.RequestServices = serviceProvider.Object;

            var actionContext = new ActionContext
            {
                HttpContext = httpContext,
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            };

            _actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                controller: null
            );
        }

        [TestMethod]
        public void OnActionExecuting_WithValidAuthorizationHeader_AndUserExists_ShouldReturnUnauthorized()
        {
            var token = "valid-token";
            _actionExecutingContext.HttpContext.Request.Headers["Authorization"] = token;
            _sessionServiceMock
                .Setup(x => x.GetUserByToken(token))
                .Returns(new User());
            _filter.OnActionExecuting(_actionExecutingContext);
            var result = _actionExecutingContext.Result as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [TestMethod]
        public void OnActionExecuting_WithValidAuthorizationHeader_AndUserDoesNotExist_ShouldProceed()
        {
            var token = "invalid-token";
            _actionExecutingContext.HttpContext.Request.Headers["Authorization"] = token;

            _sessionServiceMock
                .Setup(x => x.GetUserByToken(token))
                .Returns((User)null);

            _filter.OnActionExecuting(_actionExecutingContext);

            Assert.IsNull(_actionExecutingContext.Result);
        }

        [TestMethod]
        public void OnActionExecuting_WithoutAuthorizationHeader_ShouldProceed()
        {
            _filter.OnActionExecuting(_actionExecutingContext);
            Assert.IsNull(_actionExecutingContext.Result);
        }
    }
}
