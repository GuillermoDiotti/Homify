namespace Homify.WebApi.Controllers.Session.Models.Responses;

public class CreateSessionResponse
{
    public string Token { get; init; } = null!;
    public List<string> Roles { get; init; } = null!;
    public CreateSessionResponse(BusinessLogic.Sessions.Entities.Session session, BusinessLogic.Users.Entities.User user)
    {
        Token = session.AuthToken;
        Roles = [];
        foreach (var role in user.Roles)
        {
            Roles.Add(role.Role.Name);
        }
    }

    public CreateSessionResponse()
    {
    }
}
