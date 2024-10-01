using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Exceptions;

namespace Homify.BusinessLogic.Sessions;

public class SessionService : ISessionService
{
    private readonly IRepository<Session> _repository;

    public SessionService(IRepository<Session> repository)
    {
        _repository = repository;
    }

    public Session CreateSession(User u)
    {
        Session hasSession;
        try
        {
            hasSession = _repository.Get(x => x.User.Email == u.Email);
        }
        catch (NotFoundException)
        {
            hasSession = null;
        }

        if (hasSession != null && hasSession.AuthToken != null)
        {
            return hasSession;
        }

        var newSession = new Session()
        {
            AuthToken = Guid.NewGuid().ToString(), Id = Guid.NewGuid().ToString(), User = u,
        };
        _repository.Add(newSession);
        return newSession;
    }

    public User? GetUserByToken(string token)
    {
        try
        {
            var session = _repository.Get(x => x.AuthToken == token);
            return session.User;
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
