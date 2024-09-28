using Homify.BusinessLogic.Admins.Entities;
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
using Homify.BusinessLogic.SystemPermissions;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Contexts.TestContext;
using Homify.DataAccess.Repositories.Roles;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Contexts;

public sealed class HomifyDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<HomeDevice> HomeDevices { get; set; }
    public DbSet<HomeOwner> HomeOwners { get; set; }
    public DbSet<Home> Homes { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Camera> Cameras { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<HomeUser> HomeUser { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<CompanyOwner> CompanyOwners { get; set; }
    private DbSet<SystemPermission> Permissions { get; set; }
    private DbSet<Role> Roles { get; set; }

    public HomifyDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensor>().ToTable("Sensors");
        modelBuilder.Entity<Camera>().ToTable("Cameras");

        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<HomeUser>().ToTable("HomeUsers");
        modelBuilder.Entity<HomeOwner>().ToTable("HomeOwners");

        modelBuilder.Entity<HomeOwner>()
            .HasMany(h => h.Homes)
            .WithOne(o => o.Owner)
            .HasForeignKey(i => i.OwnerId)
            .IsRequired();

        modelBuilder.Entity<HomeUser>()
            .HasMany(p => p.Permissions)
            .WithOne(h => h.HomeUser)
            .HasForeignKey(hp => new { hp.HomeId, hp.UserId })
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Home>()
            .HasMany(u => u.NofificatedMembers)
            .WithOne(h => h.Home)
            .HasForeignKey(i => i.HomeId)
            .IsRequired();

        modelBuilder.Entity<Home>()
            .HasMany(d => d.Devices)
            .WithOne(h => h.Home)
            .HasForeignKey(i => i.HomeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<HomeDevice>()
            .HasKey(hd => new
            {
                hd.HomeId,
                hd.DeviceId
            });
        modelBuilder.Entity<HomeUser>()
            .HasKey(hu => new
            {
                hu.HomeId,
                hu.UserId
            });

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Permissions);

        modelBuilder.Entity<SystemPermission>()
            .HasKey(sp => sp.Value);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .IsRequired();

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
