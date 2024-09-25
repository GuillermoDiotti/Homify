using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.HouseOwner.Entities;

public class CreateHomeOwnerArgs
{
    public readonly string Name;
    public readonly string Email;
    public readonly string Password;
    public readonly string LastName;
    public readonly string ProfilePicUrl;

    public CreateHomeOwnerArgs(string name, string email, string password, string lastName, string pfp)
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
            throw new ArgsNullException("name cannot be null or empty");
        }

        ProfilePicUrl = pfp;
    }
}
