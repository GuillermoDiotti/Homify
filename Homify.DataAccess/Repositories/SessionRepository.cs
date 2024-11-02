using System.Linq.Expressions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public sealed class SessionRepository : Repository<Session>
{
    public SessionRepository(DbContext context)
        : base(context)
    {
    }

    public override Session Get(Expression<Func<Session, bool>> expression)
    {
        var query =
            _entities.Include(s => s.User)
                .Include(s => s.User.Roles)
                .Include(s => s.User.Roles.Permissions)
                .Where(expression);

        var session = query.FirstOrDefault();

        if (session == null)
        {
            throw new NotFoundException($"User not found");
        }

        return session;
    }
}
