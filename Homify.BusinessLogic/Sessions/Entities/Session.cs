using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions.Entities;
public class Session
{
    public string Id { get; init; }
    public Guid AuthToken { get; set; }
    public User User { get; set; } = new User();

    public Session()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Session(Guid token, User user)
    {
        Id = Guid.NewGuid().ToString();
        AuthToken = token;
        User = user;
    }
}
