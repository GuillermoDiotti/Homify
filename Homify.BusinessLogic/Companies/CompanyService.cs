using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;
using Homify.Utility;

namespace Homify.BusinessLogic.Companies;

public class CompanyService : ICompanyService
{
    private readonly IRepository<Company> _repository;

    public CompanyService(IRepository<Company> repository)
    {
        _repository = repository;
    }

    public Company Add(CreateCompanyArgs args, User user)
    {
        CompanyOwner owner = (CompanyOwner)user;

        var company = new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = args.Name,
            LogoUrl = args.LogoUrl,
            Rut = args.Rut,
            Owner = owner
        };

        _repository.Add(company);
        return company;
    }
}
