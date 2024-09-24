using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Sessions;
public interface ISessionService
{
    Session AddToken(User user);
}
