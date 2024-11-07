using Homify.BusinessLogic.Sessions;
using Homify.BusinessLogic.Users;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Session.Models.Requests;
using Homify.WebApi.Controllers.Session.Models.Responses;
using Homify.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Session;

[ApiController]
[Route("sessions")]
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
    [NonAuthenticationFilter]
    public CreateSessionResponse Create(CreateSessionRequest? request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request can not be null");
        }

        var userFound = _sessionService.CheckSessionConstraints(request.Email, request.Password);

        BusinessLogic.Sessions.Entities.Session sessionSaved = _sessionService.CreateSession(userFound);

        return new CreateSessionResponse(sessionSaved);
    }
}
