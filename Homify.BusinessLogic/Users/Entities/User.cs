using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Utility;

namespace Homify.BusinessLogic.Users.Entities;

public class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; init; }
    public string? ProfilePicture { get; set; } = null!;
    public Role Role { get; init; } = null!;
    public string RoleId { get; set; } = null!;
    public string CreatedAt { get; init; }

    public User(string name, string email, string password, string lastName, Role role)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Email = email;
        Password = password;
        LastName = lastName;
        Role = role;
        RoleId = role.Id;
        CreatedAt = HomifyDateTime.GetActualDate();
    }

    public User()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = HomifyDateTime.GetActualDate();
    }
}
