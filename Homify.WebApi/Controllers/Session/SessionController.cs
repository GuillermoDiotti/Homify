using Homify.BusinessLogic.Sessions;
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

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    [NonAuthenticationFilter]
    public CreateSessionResponse Create(CreateSessionRequest? request)
    {
        Helpers.ValidateRequest(request);

        var userFound = _sessionService.CheckSessionConstraints(request.Email, request.Password);

        BusinessLogic.Sessions.Entities.Session sessionSaved = _sessionService.CreateSession(userFound);

        return new CreateSessionResponse(sessionSaved, userFound);
    }
}
