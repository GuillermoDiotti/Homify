using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.Exceptions;
using InvalidOperationException = Homify.Exceptions.InvalidOperationException;

namespace Homify.BusinessLogic.Companies;

public class CreateCompanyArgs
{
    public readonly string Name;
    public readonly string LogoUrl;
    public readonly string Rut;
    public readonly string Validator;
    public readonly CompanyOwner Owner;

    public CreateCompanyArgs(string name, string logoUrl, string rut, string validator, CompanyOwner? owner)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgsNullException("name cannot be null or empty");
        }

        Name = name;

        if (string.IsNullOrWhiteSpace(logoUrl))
        {
            throw new ArgsNullException("logo image cannot be null or empty");
        }

        LogoUrl = logoUrl;

        if (string.IsNullOrWhiteSpace(rut))
        {
            throw new ArgsNullException("rut cannot be null or empty");
        }

        Rut = rut;

        if (owner == null)
        {
            throw new InvalidOperationException("Only a CompanyOwner can create a company.");
        }

        if (!owner.IsIncomplete)
        {
            throw new InvalidOperationException("Account must be incomplete to execute this action.");
        }

        Owner = owner;
        Validator = validator;
    }
}
