﻿using System.Net;
using Homify.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.WebApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly Dictionary<Type, Func<System.Exception, IActionResult>>
     _errors = new Dictionary<Type, Func<System.Exception, IActionResult>>
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
            typeof(ArgumentNullException), exception =>
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
        {
            typeof(ArgumentException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "Invalid Argument",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
        {
            typeof(InvalidOperationException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "InvalidOperation",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
        {
            typeof(InvalidDataException), exception =>
                new ObjectResult(new
                {
                    InnerCode = "InvalidData",
                    Message = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
        },
     };

    public void OnException(ExceptionContext context)
    {
        Type exceptionType = context.Exception.GetType();
        Func<System.Exception, IActionResult>? responseBuilder = _errors.GetValueOrDefault(exceptionType);

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
