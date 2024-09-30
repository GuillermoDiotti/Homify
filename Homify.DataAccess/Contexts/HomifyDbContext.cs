using System.Diagnostics.CodeAnalysis;
using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Cameras.Entities;
using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Sensors.Entities;
using Homify.BusinessLogic.Sessions.Entities;
using Homify.BusinessLogic.SystemPermissions;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Contexts.TestContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Homify.DataAccess.Contexts;

[ExcludeFromCodeCoverage]
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

     public DbSet<SystemPermission> Permissions { get; set; }
     public DbSet<Role> Roles { get; set; }

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

        modelBuilder.Entity<Company>()
            .HasMany(d => d.Devices)
            .WithOne(c => c.Company)
            .HasForeignKey(i => i.CompanyId)
            .IsRequired();

        modelBuilder.Entity<Company>()
            .HasOne(c => c.Owner)
            .WithOne(co => co.Company)
            .HasForeignKey<CompanyOwner>(co => co.Id);

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

        modelBuilder.Entity<SystemPermission>().HasData(
            new SystemPermission { Value = PermissionsGenerator.CreateAdmin },
            new SystemPermission { Value = PermissionsGenerator.DeleteAdmin },
            new SystemPermission { Value = PermissionsGenerator.GetAllAccounts },
            new SystemPermission { Value = PermissionsGenerator.CreateCompanyOwner },
            new SystemPermission { Value = PermissionsGenerator.GetCompanies },
            new SystemPermission { Value = PermissionsGenerator.CreateCompany },
            new SystemPermission { Value = PermissionsGenerator.RegisterCamera },
            new SystemPermission { Value = PermissionsGenerator.RegisterSensor },
            new SystemPermission { Value = PermissionsGenerator.CreateHome },
            new SystemPermission { Value = PermissionsGenerator.UpdateHomeMembersList },
            new SystemPermission { Value = PermissionsGenerator.UpdateHomeDevices },
            new SystemPermission { Value = PermissionsGenerator.GetHomeMembers },
            new SystemPermission { Value = PermissionsGenerator.GetHomeDevices },
            new SystemPermission { Value = PermissionsGenerator.UpdateHomeNotificatedMembers },
            new SystemPermission { Value = PermissionsGenerator.GetUserNotifications },
            new SystemPermission { Value = PermissionsGenerator.UpdateUserNotification },
            new SystemPermission { Value = PermissionsGenerator.ViewRegisteredDevices },
            new SystemPermission { Value = PermissionsGenerator.ViewSupportedDevices },
            new SystemPermission { Value = PermissionsGenerator.CreateNotification }
        );

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
