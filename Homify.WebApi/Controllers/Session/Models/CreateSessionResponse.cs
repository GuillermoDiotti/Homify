namespace Homify.WebApi.Controllers.Session.Models;

public class CreateSessionResponse
{
    public string Token { get; init; } = null!;
    public CreateSessionResponse(BusinessLogic.Sessions.Entities.Session session)
    {
        Token = session.AuthToken;
    }

    public CreateSessionResponse()
    {
    }
}
