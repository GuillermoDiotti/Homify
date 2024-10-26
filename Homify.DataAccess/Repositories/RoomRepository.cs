using System.Linq.Expressions;
using Homify.DataAccess.Repositories.Rooms.Entities;
using Homify.Exceptions;
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
        if (room == null)
        {
            throw new NotFoundException("Room not found");
        }

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
