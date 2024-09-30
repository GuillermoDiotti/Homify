using System.Linq.Expressions;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
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
                .Include(s => s.User.Role)
                .Include(s => s.User.Role.Permissions)
                .Where(expression);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new InvalidOperationException($"User not found");
        }

        return user;
    }
}
