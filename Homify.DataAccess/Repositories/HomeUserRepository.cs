﻿using System.Linq.Expressions;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class HomeUserRepository : Repository<HomeUser>
{
    public HomeUserRepository(DbContext context)
        : base(context)
    {
    }

    public override HomeUser? Get(Expression<Func<HomeUser, bool>> expression)
    {
        var query =
            _entities.Include(s => s.User)
                .Include(s => s.User.Roles)
                .ThenInclude(r => r.Role)
                .ThenInclude(u => u.Permissions)
                .Include(s => s.Home)
                .Include(s => s.Home.Devices)
                .Include(s => s.Permissions)
                .Where(expression);

        var session = query.FirstOrDefault();

        if (session == null)
        {
            throw new NotFoundException($"User not found");
        }

        return session;
    }
}
