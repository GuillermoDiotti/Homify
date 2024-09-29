using Homify.BusinessLogic.Sessions.Entities;

namespace Homify.BusinessLogic.Sessions;
public interface ISessionService
{
    Session AddToken(string userEmail);
}
