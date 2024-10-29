using Homify.BusinessLogic.CompanyOwners.Entities;

namespace Homify.BusinessLogic.CompanyOwners;

public interface ICompanyOwnerService
{
    CompanyOwner? GetById(string id);
}
