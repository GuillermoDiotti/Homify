﻿using System.Linq.Expressions;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class HomePermissionRepository : Repository<HomePermission>
{
    public HomePermissionRepository(DbContext context)
        : base(context)
    {
    }

    public override HomePermission? Get(Expression<Func<HomePermission, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.HomeUsers)
                .Where(predicate);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"HomePermission not found");
        }

        return user;
    }
}
