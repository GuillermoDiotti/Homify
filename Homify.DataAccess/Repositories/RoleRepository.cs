using System.Linq.Expressions;
using Homify.BusinessLogic.Roles.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class RoleRepository : Repository<Role>
{
    public RoleRepository(DbContext context)
        : base(context)
    {
    }

    public override Role Get(Expression<Func<Role, bool>> expression)
    {
        var query =
            _entities.Include(u => u.Permissions)
                .Where(expression);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"Role not found");
        }

        return user;
    }
}
