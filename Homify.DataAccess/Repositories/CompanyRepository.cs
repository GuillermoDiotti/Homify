using System.Linq.Expressions;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;

public class CompanyRepository : Repository<Company>
{
    public CompanyRepository(DbContext context)
        : base(context)
    {
    }

    public override Company? Get(Expression<Func<Company, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Owner)
                .Include(u => u.Devices)
                .Where(predicate);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new InvalidOperationException($"User not found");
        }

        return user;
    }
}
