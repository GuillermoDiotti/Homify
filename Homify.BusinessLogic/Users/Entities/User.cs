using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Roles.Entities;
using Homify.BusinessLogic.UserRoles.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Users.Entities;

public record class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; init; }
    public string? ProfilePicture { get; set; } = null!;
    public List<UserRole> Roles { get; init; } = null!;
    public string CreatedAt { get; init; }
    public List<Home> Homes { get; init; }

    public User(string name, string email, string password, string lastName, Role role)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Email = email;
        Password = password;
        LastName = lastName;
        CreatedAt = HomifyDateTime.GetActualDate();
        Roles = [new UserRole(this, role)];

        Homes = [];
    }

    public User()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = HomifyDateTime.GetActualDate();
        Roles = [];

        Homes = [];
    }
}
