using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions;
public interface ISessionService
{
    Session Create(User u);
    User? GetUserByToken(string token);
    User CheckConstraints(string? mail, string? password);
}
