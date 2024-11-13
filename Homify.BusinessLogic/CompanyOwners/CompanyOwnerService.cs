using Homify.BusinessLogic.CompanyOwners.Entities;

namespace Homify.BusinessLogic.CompanyOwners;

public class CompanyOwnerService : ICompanyOwnerService
{
    private readonly IRepository<CompanyOwner> _repository;
    public CompanyOwnerService(IRepository<CompanyOwner> repository)
    {
        _repository = repository;
    }

    public CompanyOwner? GetById(string id)
    {
        return _repository.Get(x => x.Id == id);
    }
}
