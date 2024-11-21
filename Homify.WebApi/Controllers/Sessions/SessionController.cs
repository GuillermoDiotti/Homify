using Homify.BusinessLogic.Sessions;
using Homify.Utility;
using Homify.WebApi.Controllers.Sessions.Models.Requests;
using Homify.WebApi.Controllers.Sessions.Models.Responses;
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

        var userFound = _sessionService.CheckConstraints(request.Email, request.Password);

        BusinessLogic.Sessions.Entities.Session sessionSaved = _sessionService.Create(userFound);

        return new CreateSessionResponse(sessionSaved, userFound);
    }
}
