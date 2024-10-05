using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class HomeDeviceRepository : Repository<HomeDevice>
{
    [ExcludeFromCodeCoverage]
    public HomeDeviceRepository(DbContext context)
        : base(context)
    {
    }

    public override HomeDevice Get(Expression<Func<HomeDevice, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Home)
                .Include(u => u.Device)
                .Where(predicate);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"User not found");
        }

        return user;
    }

    public override List<HomeDevice> GetAll(Expression<Func<HomeDevice, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Home)
                .Include(u => u.Device).ToList();
        }

        var query =
            _entities.Include(u => u.Home)
                .Include(u => u.Device)
                .Where(predicate).ToList();

        return query;
    }
}
