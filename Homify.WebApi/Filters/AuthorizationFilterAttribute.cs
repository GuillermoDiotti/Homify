using System.Net;
using Homify.BusinessLogic.SystemPermissions;
using Homify.BusinessLogic.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homify.WebApi.Filters;

public sealed class AuthorizationFilter : AuthenticationFilterAttribute
{
    public string Code { get; set; }

    public AuthorizationFilter(string code)
    {
        Code = code;
    }

    public override void OnAuthorization(AuthorizationFilterContext context)
    {
        base.OnAuthorization(context);

        var userLogged = (User)context.HttpContext.Items[Items.UserLogged];

        if (userLogged != null && !HasPermission(userLogged, Code))
        {
            context.Result = new ObjectResult(new
            {
                InnerCode = "Unauthorized",
                Message = "You are not authorized"
            })
            {
                StatusCode = (int)HttpStatusCode.Forbidden
            };
        }
    }

    private bool HasPermission(User userLogged, string code)
    {
        foreach (SystemPermission permission in userLogged.Role.Permissions)
        {
            if (permission.Value == code)
            {
                return true;
            }
        }

        return false;
    }
}
