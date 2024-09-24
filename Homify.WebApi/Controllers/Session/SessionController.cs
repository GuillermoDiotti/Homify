using Homify.BusinessLogic.Users.Entities;
using Homify.BusinessLogic.Sessions;
using Homify.WebApi.Controllers.Session.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Session;

public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public CreateSessionResponse Create(CreateSessionRequest? request)
    {
        if (request == null)
        {
            throw new Exception("Request can not be null");
        }

        /*
        var user = new User
        {
            Email = request.Email,
            Password = request.Password
        };

        Session sessionSaved = _sessionService.AddToken(user);

        return new CreateSessionResponse(sessionSaved);*/
        return new CreateSessionResponse();
    }
}
