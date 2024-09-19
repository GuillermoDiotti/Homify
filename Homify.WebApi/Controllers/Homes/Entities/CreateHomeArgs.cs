using Homify.Exceptions;

namespace Homify.WebApi.Controllers.Homes.Entities;

public class CreateHomeArgs
{
    public readonly string Street;
    public readonly string Number;
    public readonly string Latitude;
    public readonly string Longitude;

    public CreateHomeArgs(string street, string number, string latitude, string longitude)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgsNullException("name cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgsNullException("number cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(latitude))
        {
            throw new ArgsNullException("latitude cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(longitude))
        {
            throw new ArgsNullException("longitude cannot be null or empty");
        }

        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
    }
}
