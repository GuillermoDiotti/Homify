using System.Linq.Expressions;
using Homify.BusinessLogic.Homes.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class HomeRepository : Repository<Home>
{
    public HomeRepository(DbContext context)
        : base(context)
    {
    }

    public override Home? Get(Expression<Func<Home, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Devices)
                .Include(u => u.Owner)
                .Include(u => u.Members)
                .ThenInclude(m => m.Permissions)
                .Where(predicate);

        var home = query.FirstOrDefault();

        if (home == null)
        {
            throw new NotFoundException($"Home not found");
        }

        return home;
    }
}
