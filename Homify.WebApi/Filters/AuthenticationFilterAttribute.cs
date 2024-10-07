using System.Net;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homify.WebApi.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthenticationFilterAttribute : Attribute, IAuthorizationFilter
{
    private const string AUTHORIZATION_HEADER = "Authorization";
    public virtual void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers[AUTHORIZATION_HEADER];
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            context.Result = new ObjectResult(new
            {
                InnerCode = "Unauthenticated",
                Message = "You are not authenticated"
            })
            {
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
            return;
        }

        var authorization = authorizationHeader.ToString();
        if (string.IsNullOrEmpty(authorization))
        {
            context.Result = new ObjectResult(new
            {
                InnerCode = "Unauthenticated",
                Message = "You are not authenticated"
            })
            {
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
            return;
        }

        var user = GetUserOfAuthorization(authorization, context);
        if (user == null)
        {
            context.Result = new ObjectResult(new
            {
                InnerCode = "Unauthenticated",
                Message = "You are not authenticated"
            })
            {
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
            return;
        }

        context.HttpContext.Items[Items.UserLogged] = user;
    }

    private User? GetUserOfAuthorization(string authorization, AuthorizationFilterContext context)
    {
        var sessionService = context.HttpContext.RequestServices.GetService<ISessionService>();
        User user;
        try
        {
            user = sessionService.GetUserByToken(authorization);
        }
        catch (NotFoundException)
        {
            user = null;
        }

        return user;
    }
}
