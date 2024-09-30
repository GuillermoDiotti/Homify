using System.Net;
using FluentAssertions;
using Homify.Exceptions;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

namespace Homify.Tests.FilterTests;

[TestClass]
public class ExceptionFilterTest
{
    private ExceptionContext _context;
    private ExceptionFilter _attribute;

    public ExceptionFilterTest()
    {
        _attribute = new ExceptionFilter();
        _context = new ExceptionContext(
            new ActionContext(
                new Mock<HttpContext>().Object,
                new RouteData(),
                new ActionDescriptor()),
            new List<IFilterMetadata>());
    }

    [TestMethod]
    public void OnException_WhenExceptionIsNotRegistered_ShouldResponseInternalError()
    {
        _context.Exception = new Exception("Not registered");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("InternalError");
            GetMessage(concreteResponse.Value).Should().Be("There was an error while processing the request");
        }
    }

    [TestMethod]
    public void OnException_WhenExceptionIsArgsFormatException_ShouldResponseInvalidArgumentFormat()
    {
        _context.Exception = new ArgsNullException("The email format is not valid");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("InvalidNullArgument");
            GetMessage(concreteResponse.Value).Should().Be("The email format is not valid");
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
