using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.Sessions;

public sealed class SessionService : ISessionService
{
    private readonly IRepository<Session> _repository;
    private readonly IUserService _userService;

    public SessionService(IRepository<Session> repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public Session Create(User u)
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
            AuthToken = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid().ToString(),
            User = u,
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

    public User CheckConstraints(string? mail, string? password)
    {
        if (mail == null)
        {
            throw new ArgsNullException("Email can not be null");
        }

        AccountCredentialsValidator.CheckEmail(mail ?? string.Empty);

        var userFound = _userService.GetAll().Find(u => u.Email == mail);

        if (userFound == null)
        {
            throw new NotFoundException("Cannot find user with email: " + mail);
        }

        AccountCredentialsValidator.CheckPassword(password ?? string.Empty);

        if (password != userFound.Password)
        {
            throw new ArgumentException("Incorrect password");
        }

        return userFound;
    }
}
