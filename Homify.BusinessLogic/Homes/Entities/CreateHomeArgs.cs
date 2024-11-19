using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.Homes.Entities;

public class CreateHomeArgs
{
    public readonly string Street;
    public readonly string Number;
    public readonly string Latitude;
    public readonly string Longitude;
    public readonly int MaxMembers;
    public readonly string Alias;
    public readonly HomeOwner Owner;

    public CreateHomeArgs(string street, string number, string latitude, string longitude, int maxMembers, HomeOwner? owner, string alias)
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

        if (maxMembers < 1)
        {
            throw new ArgsNullException("max members cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(alias))
        {
            throw new ArgsNullException("alias cannot be null or empty");
        }

        if (owner == null)
        {
            throw new ArgsNullException("owner cannot be null");
        }

        if (!owner.Roles.Any(x => x.Role.Name == Constants.HOMEOWNER))
        {
            throw new Exceptions.InvalidOperationException("Owner must have homeowner role");
        }

        Owner = owner;
        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        MaxMembers = maxMembers;
        Alias = alias;
    }
}
