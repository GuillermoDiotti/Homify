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
using Homify.Utility;
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
    public DbSet<SystemPermission> SystemPermissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleSystemPermission> RoleSystemPermissions { get; set; }

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

    modelBuilder.Entity<User>()
        .HasOne(u => u.Role)
        .WithMany()
        .HasForeignKey(u => u.RoleId)
        .IsRequired();

    modelBuilder.Entity<Role>()
        .HasMany(r => r.Permissions)
        .WithMany(p => p.Roles)
        .UsingEntity<RoleSystemPermission>();

    modelBuilder.Entity<SystemPermission>().HasData(
        new SystemPermission { Id = "1", Value = PermissionsGenerator.CreateAdmin },
        new SystemPermission { Id = "2", Value = PermissionsGenerator.DeleteAdmin },
        new SystemPermission { Id = "3", Value = PermissionsGenerator.GetAllAccounts },
        new SystemPermission { Id = "4", Value = PermissionsGenerator.CreateCompanyOwner },
        new SystemPermission { Id = "5", Value = PermissionsGenerator.GetCompanies },
        new SystemPermission { Id = "6", Value = PermissionsGenerator.CreateCompany },
        new SystemPermission { Id = "7", Value = PermissionsGenerator.RegisterCamera },
        new SystemPermission { Id = "8", Value = PermissionsGenerator.RegisterSensor },
        new SystemPermission { Id = "9", Value = PermissionsGenerator.CreateHome },
        new SystemPermission { Id = "10", Value = PermissionsGenerator.UpdateHomeMembersList },
        new SystemPermission { Id = "11", Value = PermissionsGenerator.UpdateHomeDevices },
        new SystemPermission { Id = "12", Value = PermissionsGenerator.GetHomeMembers },
        new SystemPermission { Id = "13", Value = PermissionsGenerator.GetHomeDevices },
        new SystemPermission { Id = "14", Value = PermissionsGenerator.UpdateHomeNotificatedMembers },
        new SystemPermission { Id = "15", Value = PermissionsGenerator.GetUserNotifications },
        new SystemPermission { Id = "16", Value = PermissionsGenerator.UpdateUserNotification },
        new SystemPermission { Id = "17", Value = PermissionsGenerator.ViewRegisteredDevices },
        new SystemPermission { Id = "18", Value = PermissionsGenerator.ViewSupportedDevices },
        new SystemPermission { Id = "19", Value = PermissionsGenerator.CreateNotification }
    );

    modelBuilder.Entity<Role>().HasData(
        new Role
        {
            Id = "adminid",
            Name = Constants.ADMINISTRATOR
        },
        new Role
        {
            Id = "companyownerId",
            Name = Constants.COMPANYOWNER
        },
        new Role
        {
            Id = "homeownerId",
            Name = Constants.HOMEOWNER
        }
    );
    modelBuilder.Entity<RoleSystemPermission>()
        .HasKey(rp => new { rp.RoleSystemPermissionId });

    modelBuilder.Entity<RoleSystemPermission>().HasOne(r => r.Role)
        .WithMany()
        .HasForeignKey(r => r.RoleId);

    modelBuilder.Entity<RoleSystemPermission>().HasOne(r => r.Permission)
        .WithMany()
        .HasForeignKey(r => r.PermissionId);

    modelBuilder.Entity<RoleSystemPermission>().HasData(
            new RoleSystemPermission
            {
                RoleId = "adminid",
                PermissionId = "1"
            },
            new RoleSystemPermission
            {
                RoleId = "adminid",
                PermissionId = "2"
            },
            new RoleSystemPermission
            {
                RoleId = "adminid",
                PermissionId = "3"
            },
            new RoleSystemPermission
            {
                RoleId = "adminid",
                PermissionId = "4"
            },
            new RoleSystemPermission
            {
                RoleId = "adminid",
                PermissionId = "5"
            },
            new RoleSystemPermission
            {
                RoleId = "companyownerId",
                PermissionId = "6"
            },
            new RoleSystemPermission
            {
                RoleId = "companyownerId",
                PermissionId = "7"
            },
            new RoleSystemPermission
            {
                RoleId = "companyownerId",
                PermissionId = "8"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "9"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "10"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "11"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "12"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "13"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "14"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "15"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "16"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "17"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "18"
            },
            new RoleSystemPermission
            {
                RoleId = "homeownerId",
                PermissionId = "19"
            }
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

    public sealed record class RoleSystemPermission
    {
        public string RoleSystemPermissionId { get; set; } = Guid.NewGuid().ToString();
        public string? RoleId { get; set; }
        public Role? Role { get; set; }

        public string? PermissionId { get; set; }
        public SystemPermission? Permission { get; set; }
    }
}
