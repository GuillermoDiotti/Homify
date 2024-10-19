using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;
using Homify.Exceptions;

namespace Homify.BusinessLogic.HomeOwners.Entities;

public class CreateHomeOwnerArgs : CreateUserArgs
{
    public readonly string ProfilePicUrl;

    public CreateHomeOwnerArgs(string name, string email, string password, string lastName, string pfp, Role? role)
        : base(name, email, password, lastName, role)
    {
        if (string.IsNullOrWhiteSpace(pfp))
        {
            throw new ArgsNullException("profile picture cannot be null or empty");
        }

        ProfilePicUrl = pfp;
    }
}
