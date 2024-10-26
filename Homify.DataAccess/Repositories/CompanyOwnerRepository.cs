using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Repositories;
[ExcludeFromCodeCoverage]
public class CompanyOwnerRepository : Repository<CompanyOwner>
{
    public CompanyOwnerRepository(DbContext context)
        : base(context)
    {
    }

    public override CompanyOwner? Get(Expression<Func<CompanyOwner, bool>> predicate)
    {
        var query =
            _entities.Include(u => u.Company)
                .ThenInclude(u => u.Devices)
                .Where(predicate);

        var user = query.FirstOrDefault();

        if (user == null)
        {
            throw new NotFoundException($"User not found");
        }

        return user;
    }
}
