namespace Homify.BusinessLogic.Admins.Entities;

public class Admin
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }

    public Admin()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
