using Homify.Exceptions;

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

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgsNullException("email cannot be null or empty");
        }

        if (!EmailFormatValidator(email))
        {
            throw new InvalidFormatException("email format is invalid");
        }

        Email = email;

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgsNullException("password cannot be null or empty");
        }

        if (!PasswordFormatValidator(password))
        {
            throw new InvalidFormatException("password format is invalid");
        }

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

    private bool EmailFormatValidator(string email)
    {
        return email.Contains("@") && email.EndsWith(".com");
    }

    private bool PasswordFormatValidator(string password)
    {
        return password.Length > 3 && password.Length < 50;
    }
}
