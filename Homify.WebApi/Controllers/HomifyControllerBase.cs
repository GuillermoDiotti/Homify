using Homify.BusinessLogic.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers;

public class HomifyControllerBase : ControllerBase
{
    public User GetUserLogged()
    {
        var userLogged = HttpContext.Items[Items.UserLogged];

        var userLoggedMapped = (User)userLogged;

        return userLoggedMapped;
    }
}
