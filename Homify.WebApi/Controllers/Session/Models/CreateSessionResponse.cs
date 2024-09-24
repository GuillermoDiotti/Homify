namespace Homify.WebApi.Controllers.Session.Models;

public class CreateSessionResponse
{
    public Guid Token { get; init; }
    public CreateSessionResponse(BusinessLogic.Sessions.Entities.Session session)
    {
        Token = session.AuthToken;
    }

    public CreateSessionResponse()
    {
    }
}
