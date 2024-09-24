using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions.Entities;
public class Session
{
    public int Id { get; set; }
    public Guid AuthToken { get; set; }
    public User User { get; set; } = new User();

    public Session()
    {
    }

    public Session(Guid token, User user)
    {
        AuthToken = token;
        User = user;
    }
}
