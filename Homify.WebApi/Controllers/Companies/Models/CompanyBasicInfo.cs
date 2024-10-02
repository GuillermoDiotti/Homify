using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;

namespace Homify.WebApi.Controllers.Companies.Models;

public sealed record class CompanyBasicInfo
{
    public string CompanyName { get; init; } = null!;
    public string OwnerName { get; init; } = null!;
    public string OwnerMail { get; init; } = null!;
    public string Rut { get; init; } = null!;

    public CompanyBasicInfo(Company company, CompanyOwner owner)
    {
        CompanyName = company.Name;
        OwnerName = owner.Name;
        OwnerMail = owner.Email;
        Rut = company.Rut;
    }
}
