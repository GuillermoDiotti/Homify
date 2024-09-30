using System.Net;
using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace Homify.WebApi.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthenticationFilterAttribute : Attribute, IAuthorizationFilter
{
    private const string AUTHORIZATION_HEADER = "Authorization";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(AUTHORIZATION_HEADER, out var authorizationHeader) || string.IsNullOrEmpty(authorizationHeader))
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
        User user = sessionService.GetUserByToken(authorization);
        return user;
    }
}
