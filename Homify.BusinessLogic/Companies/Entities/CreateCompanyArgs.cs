using Homify.Exceptions;

namespace Homify.BusinessLogic.Companies;

public class CreateCompanyArgs
{
    public readonly string Name;
    public readonly string LogoUrl;
    public readonly string Rut;

    public CreateCompanyArgs(string name, string logoUrl, string rut)
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
    }
}
