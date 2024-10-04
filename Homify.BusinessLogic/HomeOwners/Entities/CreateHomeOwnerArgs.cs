using Homify.BusinessLogic.Roles;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.HomeOwners.Entities;

public class CreateHomeOwnerArgs
{
    public readonly string Name;
    public readonly string Email;
    public readonly string Password;
    public readonly string LastName;
    public readonly string ProfilePicUrl;
    public readonly Role? Role;

    public CreateHomeOwnerArgs(string name, string email, string password, string lastName, string pfp, Role? role)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgsNullException("name cannot be null or empty");
        }

        Name = name;

        AccountCredentialsValidator.CheckEmail(email);

        Email = email;

        AccountCredentialsValidator.CheckPassword(password);

        Password = password;

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgsNullException("last name cannot be null or empty");
        }

        LastName = lastName;

        if (string.IsNullOrWhiteSpace(pfp))
        {
            throw new ArgsNullException("profile picture cannot be null or empty");
        }

        if (role == null)
        {
            throw new ArgsNullException("Role cannot be null");
        }

        Role = role;

        ProfilePicUrl = pfp;
    }
}
