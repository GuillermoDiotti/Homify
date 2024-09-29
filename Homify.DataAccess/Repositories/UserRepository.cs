using System.Linq.Expressions;
using Homify.BusinessLogic.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public sealed class UserRepository : Repository<User>
{
    public UserRepository(DbContext context)
        : base(context)
    {
    }

    public override User? Get(Expression<Func<User, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Role)
                .Include(u => u.Role.Permissions)
                .Where(predicate);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new InvalidOperationException($"User not found");
        }

        return user;
    }

    public override List<User> GetAll(Expression<Func<User, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Role)
                .Include(u => u.Role.Permissions).ToList();
        }

        var query =
            _entities.Include(u => u.Role)
                .Include(u => u.Role.Permissions)
                .Where(predicate)
                .ToList();

        return query;
    }
}
