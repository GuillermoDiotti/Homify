using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;
using Homify.Utility;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

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
        var owner = (CompanyOwner)user;

        var nameExists = GetAll().Any(x => x.Name == args.Name);

        if (nameExists)
        {
            throw new DuplicatedDataException("The name is already taken.");
        }

        var alreadyHasACompany = GetByOwner(args.Owner.Id);

        if (alreadyHasACompany != null)
        {
            throw new InvalidOperationException("User already owns a company");
        }

        owner.IsIncomplete = false;
        var company = new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = args.Name,
            LogoUrl = args.LogoUrl,
            Rut = args.Rut,
            ValidatorType = args.Validator,
            Owner = owner
        };

        _repository.Add(company);
        return company;
    }

    public Company? GetByOwner(string userId)
    {
        try
        {
            return _repository.Get(x => x.OwnerId == userId);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    public List<Company> GetAll(string? owner = null, string? company = null)
    {
        var list = _repository.GetAll();

        if (!string.IsNullOrEmpty(owner))
        {
            list = list.Where(c => Helpers.GetUserFullName(c.Owner.Name, c.Owner.LastName)
                .Contains(owner, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(company))
        {
            list = list.Where(c => c.Name.Contains(company, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return list;
    }

    public string AddValidatorModel(string model, User u)
    {
        var company = _repository.Get(c => c.OwnerId == u.Id);

        if (company == null)
        {
            throw new NotFoundException("Company not found");
        }

        company.ValidatorType = model;
        _repository.Update(company);
        return model;
    }
}
