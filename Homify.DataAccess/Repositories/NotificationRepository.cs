using System.Linq.Expressions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class NotificationRepository : Repository<Notification>
{
    public NotificationRepository(DbContext context)
        : base(context)
    {
    }

    public override Notification Get(Expression<Func<Notification, bool>> expression)
    {
        var query =
            _entities.Include(u => u.Device)
                .Include(u => u.HomeUser)
                .Where(expression);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"User not found");
        }

        return user;
    }

    public override List<Notification> GetAll(Expression<Func<Notification, bool>>? predicate)
    {
        if (predicate == null)
        {
            return _entities.Include(u => u.Device)
                .Include(u => u.HomeUser)
                .ThenInclude(u => u.User)
                .ToList();
        }

        var query =
                _entities.Include(u => u.Device)
                    .Include(u => u.HomeUser)
                    .ThenInclude(u => u.User)
                    .Where(predicate)
                .ToList();

        return query;
    }
}
