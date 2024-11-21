using System.Diagnostics.CodeAnalysis;
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
                .Include(u => u.Members)
                .ThenInclude(m => m.User)
                .Where(predicate);

        var home = query.FirstOrDefault();

        if (home == null)
        {
            throw new NotFoundException($"Home not found");
        }

        return home;
    }

    public override List<Home> GetAll(Expression<Func<Home, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Members)
                .ThenInclude(u => u.Permissions)
                .Include(u => u.Devices)
                .ToList();
        }

        var query =
            _entities.Include(u => u.Members)
                .ThenInclude(u => u.Permissions)
                .Include(u => u.Devices)
                .Where(predicate)
                .ToList();

        return query;
    }
}
