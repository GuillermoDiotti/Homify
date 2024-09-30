using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Sessions;

public class SessionService : ISessionService
{
    private readonly IRepository<Session> _repository;

    public SessionService(IRepository<Session> repository)
    {
        _repository = repository;
    }

    public User GetUserByToken(string token)
    {
        var session = _repository.Get(x => x.AuthToken == token);
        return session.User;
    }
}
