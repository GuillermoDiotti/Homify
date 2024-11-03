using System.Linq.Expressions;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class UserRoleRepository : Repository<UserRole>
{
    public UserRoleRepository(DbContext context)
        : base(context)
    {
    }

    public override UserRole Get(Expression<Func<UserRole, bool>> expression)
    {
        var query =
            _entities.Include(u => u.Role)
                .ThenInclude(x => x.Permissions)
                .Include(u => u.User)
                .Where(expression);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"UserRole not found");
        }

        return user;
    }

    public override List<UserRole> GetAll(Expression<Func<UserRole, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Role)
                .ThenInclude(r => r.Permissions)
                .Include(u => u.User).ToList();
        }

        var query =
            _entities.Include(u => u.Role)
                .ThenInclude(r => r.Permissions)
                .Include(u => u.User)
                .Where(predicate)
                .ToList();

        return query;
    }
}
