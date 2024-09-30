using System.Net;
using Homify.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homify.WebApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
   private readonly Dictionary<Type, Func<Exception, IActionResult>>
    _errors = new Dictionary<Type, Func<Exception, IActionResult>>
    {
        {
            typeof(ArgsNullException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "InvalidNullArgument",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
        {
            typeof(InvalidFormatException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "InvalidArgumentFormat",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
        {
            typeof(NotFoundException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "ElementNotFound",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                }
        },
        {
            typeof(NullRequestException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "NullRequest",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
        {
            typeof(DuplicatedDataException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "DuplicatedData",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.Conflict
                }
        },
    };

public void OnException(ExceptionContext context)
{
    Type exceptionType = context.Exception.GetType();
    Func<Exception, IActionResult>? responseBuilder = _errors.GetValueOrDefault(exceptionType);

    if (responseBuilder == null)
    {
        context.Result = new ObjectResult(new
        {
            InnerCode = "InternalError",
            Message = "There was an error while processing the request"
        })
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
        return;
    }

    context.Result = responseBuilder(context.Exception);
}
}
