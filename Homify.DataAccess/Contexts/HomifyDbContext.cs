using Homify.DataAccess.Contexts.TestContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Contexts;

public class HomifyDbContext : DbContext
{
    private static readonly SqliteConnection _connection = new("Data Source=:memory:");

    public static TestDbContext BuildTestDbContext()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseSqlite(_connection)
            .Options;

        _connection.Open();

        var context = new TestDbContext(options);

        return context;
    }
}
