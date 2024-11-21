namespace Homify.WebApi.Controllers.Sessions.Models.Responses;

public sealed record class CreateSessionResponse
{
    public string Token { get; init; } = null!;
    public List<string> Roles { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string UserId { get; init; } = null!;
    public CreateSessionResponse(BusinessLogic.Sessions.Entities.Session session, BusinessLogic.Users.Entities.User user)
    {
        Token = session.AuthToken;
        Name = session.User.Name + " " + session.User.LastName;
        UserId = user.Id;
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
