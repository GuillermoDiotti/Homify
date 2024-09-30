using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions;
public interface ISessionService
{
    Session AddToken(string userEmail);
    User GetUserByToken(string token);
}
