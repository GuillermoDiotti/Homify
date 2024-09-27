using Homify.DataAccess.Repositories.Roles;

namespace Homify.BusinessLogic.Users.Entities;

public class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; init; }
    public Role Role { get; init; } = null!;
    public DateTimeOffset CreatedAt { get; init; }

    public User(string id, string name, string email, string password, string lastName, Role role)
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTimeOffset.UtcNow;
        Name = name;
        Email = email;
        Password = password;
        LastName = lastName;
        Role = role;
    }

    public User()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
