using System.Net;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homify.WebApi.Filters;

public class NonAuthenticationFilter : Attribute, IActionFilter
{
    private const string AUTHORIZATION_HEADER = "Authorization";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;
        if (headers.ContainsKey(AUTHORIZATION_HEADER))
        {
            var token = headers[AUTHORIZATION_HEADER].ToString();
            User? userLogged;

            try
            {
                userLogged = GetUserOfAuthorization(token, context);
            }
            catch (NotFoundException)
            {
                userLogged = null;
            }

            if (userLogged != null)
            {
                context.Result = new ObjectResult(new { InnerCode = "Unauthorized", Message = "You are not authorized" })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
        }
    }

    private User? GetUserOfAuthorization(string authorization, ActionExecutingContext context)
    {
        var sessionService = context.HttpContext.RequestServices.GetRequiredService<ISessionService>();

        return sessionService.GetUserByToken(authorization);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
