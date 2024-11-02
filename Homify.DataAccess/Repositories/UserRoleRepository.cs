using Homify.BusinessLogic.UserRoles.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class UserRoleRepository : Repository<UserRole>
{
    public UserRoleRepository(DbContext context)
        : base(context)
    {
    }
}
