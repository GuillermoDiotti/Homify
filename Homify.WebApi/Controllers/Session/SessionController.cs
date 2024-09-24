using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Session.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Session;

public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;
    private readonly IUserService _userService;

    public SessionController(ISessionService sessionService, IUserService userService)
    {
        _sessionService = sessionService;
        _userService = userService;
    }

    [HttpPost]
    public CreateSessionResponse Create(CreateSessionRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        if (request.Email == null)
        {
            throw new ArgumentException("Email can not be null");
        }

        var userFound = _userService.GetAll().Find(u => u.Email == request.Email);

        if (request.Password != userFound.Password)
        {
            throw new NotFoundException("Cannot find user with email: " + request.Email);
        }

        if (request.Password != userFound.Password)
        {
            throw new ArgumentException("Incorrect password");
        }

        BusinessLogic.Sessions.Entities.Session sessionSaved = _sessionService.AddToken(request.Email);

        return new CreateSessionResponse(sessionSaved);
    }
}
