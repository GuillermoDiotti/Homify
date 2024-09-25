namespace Homify.BusinessLogic.Users.Entities;

public class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public User()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
