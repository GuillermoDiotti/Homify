using Homify.Exceptions;

namespace Homify.WebApi.Controllers.Homes.Entities;

public class CreateHomeArgs
{
    public readonly string Street;

    public CreateHomeArgs(string street)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgsNullException("name cannot be null or empty");
        }

        Street = street;
    }
}
