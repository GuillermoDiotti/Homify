using System.Linq.Expressions;
using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class HomeDeviceRepository : Repository<HomeDevice>
{
    public HomeDeviceRepository(DbContext context)
        : base(context)
    {
    }

    public override HomeDevice Get(Expression<Func<HomeDevice, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Home)
                .ThenInclude(u => u.Members)
                .ThenInclude(u => u.Permissions)
                .Include(u => u.Device)
                .Include(u => u.Room)
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
                .Include(u => u.Device)
                .Include(u => u.Room)
                .ToList();
        }

        var query =
            _entities.Include(u => u.Home)
                .Include(u => u.Device)
                .Include(u => u.Room)
                .Where(predicate)
                .ToList();

        return query;
    }
}
