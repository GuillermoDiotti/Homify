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

    [TestMethod]
    public void OnException_WhenExceptionIsDateFormatException_ShouldResponseInvalidDateFormat()
    {
        _context.Exception = new InvalidFormatException("Invalid date format. Try dd-mm-yyyy");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("InvalidArgumentFormat");
            GetMessage(concreteResponse.Value).Should().Be("Invalid date format. Try dd-mm-yyyy");
        }
    }

    [TestMethod]
    public void OnException_WhenExceptionIsDateNotFoundException_ShouldResponseNotFound()
    {
        _context.Exception = new NotFoundException("User not found");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("ElementNotFound");
            GetMessage(concreteResponse.Value).Should().Be("User not found");
        }
    }

    [TestMethod]
    public void OnException_WhenExceptionIsNullRequestException_ShouldResponseNullRequest()
    {
        _context.Exception = new NullRequestException("Request is null");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("NullRequest");
            GetMessage(concreteResponse.Value).Should().Be("Request is null");
        }
    }

    [TestMethod]
    public void OnException_WhenExceptionIsDuplicatedDataException_ShouldResponseDuplicatedData()
    {
        _context.Exception = new DuplicatedDataException("User already exists");

        _attribute.OnException(_context);

        IActionResult? response = _context.Result;

        response.Should().NotBeNull();
        ObjectResult? concreteResponse = response as ObjectResult;
        concreteResponse.Should().NotBeNull();
        concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Conflict);
        if (concreteResponse.Value != null)
        {
            GetInnerCode(concreteResponse.Value).Should().Be("DuplicatedData");
            GetMessage(concreteResponse.Value).Should().Be("User already exists");
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
