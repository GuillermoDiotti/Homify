using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions.Entities;
public class Session
{
    public string Id { get; init; }
    public string AuthToken { get; set; } = null!;
    public User User { get; set; } = null!;
    public string UserId { get; set; } = null!;

    public Session()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Session(string token, User user)
    {
        Id = Guid.NewGuid().ToString();
        AuthToken = token;
        User = user;
    }
}
