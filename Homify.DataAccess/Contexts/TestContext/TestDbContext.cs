using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Contexts.TestContext;

public sealed class TestDbContext(DbContextOptions options)
    : DbContext(options)
{
    public DbSet<EntityTest> EntitiesTest { get; set; }
}
