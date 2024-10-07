using Homify.BusinessLogic.Roles;
using Homify.Exceptions;
using Homify.Utility;

namespace Homify.BusinessLogic.Users.Entities;

public class CreateUserArgs
{
    public readonly string Name;
    public readonly string Email;
    public readonly string Password;
    public readonly string LastName;
    public readonly Role Role;

    public CreateUserArgs(string name, string email, string password, string lastName, Role? role)
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

        if (role == null)
        {
            throw new ArgsNullException("user must have a role");
        }

        Role = role;
    }
}
