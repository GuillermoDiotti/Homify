using System.Linq.Expressions;
using Homify.BusinessLogic.Rooms.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class RoomRepository : Repository<Room>
{
    public RoomRepository(DbContext context)
        : base(context)
    {
    }

    public override Room? Get(Expression<Func<Room, bool>> predicate)
    {
        var query = _entities.Include(r => r.Devices)
            .Include(r => r.Home)
            .Where(predicate);

        var room = query.FirstOrDefault();

        return room;
    }

    public override List<Room> GetAll(Expression<Func<Room, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return _entities.Include(r => r.Devices)
                .Include(r => r.Home).ToList();
        }

        var query =
            _entities.Include(r => r.Devices)
                .Include(r => r.Home)
                .Where(predicate)
                .ToList();

        return query;
    }
}
