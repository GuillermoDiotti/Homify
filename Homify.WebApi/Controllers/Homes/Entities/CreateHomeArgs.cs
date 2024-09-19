using Homify.Exceptions;

namespace Homify.WebApi.Controllers.Homes.Entities;

public class CreateHomeArgs
{
    public readonly string Street;
    public readonly string Number;

    public CreateHomeArgs(string street, string number)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgsNullException("name cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgsNullException("number cannot be null or empty");
        }

        Street = street;
        Number = number;
    }
}
