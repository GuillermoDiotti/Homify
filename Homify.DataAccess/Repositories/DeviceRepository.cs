using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Homify.BusinessLogic.Devices.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;
[ExcludeFromCodeCoverage]

public class DeviceRepository : Repository<Device>
{
    public DeviceRepository(DbContext context)
        : base(context)
    {
    }

    public override List<Device> GetAll(Expression<Func<Device, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Company)
                .ThenInclude(u => u.Devices)
                .Include(u => u.Company.Owner)
                .ToList();
        }

        var query =
            _entities.Include(u => u.Company)
                .ThenInclude(u => u.Devices)
                .Include(u => u.Company.Owner)
                .Where(predicate)
                .ToList();

        return query;
    }
}
