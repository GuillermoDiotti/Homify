namespace Homify.DataAccess.Contexts.TestContext;

public sealed record class EntityTest()
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;

    public EntityTest(string name)
        : this()
    {
        Name = name;
    }
}
