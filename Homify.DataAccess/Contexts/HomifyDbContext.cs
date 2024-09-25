using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HouseOwner;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Contexts.TestContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Contexts;

public sealed class HomifyDbContext : DbContext
{
    public DbSet<Camera> Cameras { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyOwner> CompanyOwners { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<HomeDevice> HomeDevice { get; set; }
    public DbSet<HomeOwner> HomeOwner { get; set; }
    public DbSet<Home> Homes { get; set; }
    public DbSet<HomeUser> HomeUser { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }

    public HomifyDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HomeDevice>()
            .HasKey(hd => new { hd.HomeId, hd.DeviceId });
        modelBuilder.Entity<HomeUser>()
            .HasKey(hu => new { hu.HomeId, hu.UserId });

        base.OnModelCreating(modelBuilder);
    }

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
