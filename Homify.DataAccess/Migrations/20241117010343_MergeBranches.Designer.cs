﻿// <auto-generated />
using System;
using Homify.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Homify.DataAccess.Migrations
{
    [DbContext(typeof(HomifyDbContext))]
    [Migration("20241117010343_MergeBranches")]
    partial class MergeBranches
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Homify.BusinessLogic.Companies.Entities.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidatorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Devices.Device", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MovementDetection")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PeopleDetection")
                        .HasColumnType("bit");

                    b.Property<string>("Photos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PpalPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WindowDetection")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Devices");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeDevices.Entities.HomeDevice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("CustomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HardwareId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOn")
                        .HasColumnType("bit");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("HomeId");

                    b.HasIndex("RoomId");

                    b.ToTable("HomeDevices");
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeUsers.HomeUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsNotificable")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.HasIndex("UserId");

                    b.ToTable("HomeUsers", (string)null);
                });

            modelBuilder.Entity("Homify.BusinessLogic.Homes.Entities.Home", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxMembers")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Notifications.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeDeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HomeDeviceId");

                    b.HasIndex("HomeUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Permissions.HomePermissions.Entities.HomePermission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HomePermission");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Value = "AddDevices"
                        },
                        new
                        {
                            Id = "2",
                            Value = "ListDevices"
                        },
                        new
                        {
                            Id = "3",
                            Value = "ChangeDeviceName"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Permissions.SystemPermissions.Entities.SystemPermission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemPermissions");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Value = "admins-Create"
                        },
                        new
                        {
                            Id = "2",
                            Value = "admins-Delete"
                        },
                        new
                        {
                            Id = "3",
                            Value = "admins-AllAccounts"
                        },
                        new
                        {
                            Id = "4",
                            Value = "company-owners-Create"
                        },
                        new
                        {
                            Id = "5",
                            Value = "homes-ObtainCompanies"
                        },
                        new
                        {
                            Id = "6",
                            Value = "companies-Create"
                        },
                        new
                        {
                            Id = "7",
                            Value = "devices-RegisterCamera"
                        },
                        new
                        {
                            Id = "8",
                            Value = "companies-RegisterSensor"
                        },
                        new
                        {
                            Id = "9",
                            Value = "homes-Create"
                        },
                        new
                        {
                            Id = "10",
                            Value = "homes-UpdateMembersList"
                        },
                        new
                        {
                            Id = "11",
                            Value = "homes-UpdateHomeDevice"
                        },
                        new
                        {
                            Id = "12",
                            Value = "homes-ObtainMembers"
                        },
                        new
                        {
                            Id = "13",
                            Value = "homes-ObtainHomeDevices"
                        },
                        new
                        {
                            Id = "14",
                            Value = "homes-NotificatedMembers"
                        },
                        new
                        {
                            Id = "15",
                            Value = "notifications-ObtainNotifications"
                        },
                        new
                        {
                            Id = "16",
                            Value = "notifications-UpdateNotification"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Roles.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "AdminId",
                            Name = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "CompanyOwnerId",
                            Name = "COMPANYOWNER"
                        },
                        new
                        {
                            Id = "HomeOwnerId",
                            Name = "HOMEOWNER"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Rooms.Entities.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sessions.Entities.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = "SeedAdminSessionId",
                            AuthToken = "SomeAdminToken123",
                            UserId = "SeedAdminId"
                        },
                        new
                        {
                            Id = "SeedHomeOwnerSessionId",
                            AuthToken = "SomeHomeOwnerToken123",
                            UserId = "SeedHomeOwnerId"
                        },
                        new
                        {
                            Id = "SeedCompanyOwnerSessionId",
                            AuthToken = "SomeCompanyOwnerToken123",
                            UserId = "SeedCompanyOwnerId"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.UserRoles.Entities.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = "3be22b74-42cb-44b8-bcaa-198a5846379e",
                            RoleId = "AdminId",
                            UserId = "SeedAdminId"
                        },
                        new
                        {
                            Id = "a47f6035-5b19-4dff-a233-99bea8863e89",
                            RoleId = "HomeOwnerId",
                            UserId = "SeedHomeOwnerId"
                        },
                        new
                        {
                            Id = "914dc5e2-dbf9-48ff-bfcf-7d41e4010762",
                            RoleId = "CompanyOwnerId",
                            UserId = "SeedCompanyOwnerId"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Users.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Homify.DataAccess.Contexts.HomifyDbContext+HomeUserHomePermission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomePermissionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HomePermissionId");

                    b.HasIndex("HomeUserId");

                    b.ToTable("HomeUserHomePermission");
                });

            modelBuilder.Entity("Homify.DataAccess.Contexts.HomifyDbContext+RoleSystemPermission", b =>
                {
                    b.Property<string>("RoleSystemPermissionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PermissionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleSystemPermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleSystemPermissions");

                    b.HasData(
                        new
                        {
                            RoleSystemPermissionId = "9dadb15a-3e0d-4ff6-a6a0-9daeeac489c0",
                            PermissionId = "1",
                            RoleId = "AdminId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "f72653f7-9945-449b-ba15-55860c142e68",
                            PermissionId = "2",
                            RoleId = "AdminId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "3520d142-5e72-4a04-8ca2-ac58b7fdafe7",
                            PermissionId = "3",
                            RoleId = "AdminId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "b487f0bc-9bbf-4bee-8e64-cb41612a34be",
                            PermissionId = "4",
                            RoleId = "AdminId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "ca84489b-4bde-4dff-8725-c27404bf3cb1",
                            PermissionId = "5",
                            RoleId = "AdminId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "a4879157-6144-40ed-8df7-d50db59ce026",
                            PermissionId = "6",
                            RoleId = "CompanyOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "04310d63-bbf4-4757-93b7-522c42249dad",
                            PermissionId = "7",
                            RoleId = "CompanyOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "9ffffc45-88ef-44e7-842c-f6fc20bbc0ee",
                            PermissionId = "8",
                            RoleId = "CompanyOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "9d823876-7293-4600-8dcd-c24ec70745f4",
                            PermissionId = "9",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "4019de9f-b1b0-4e92-af9c-162816d58c9c",
                            PermissionId = "10",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "b283ae85-57c1-4c72-bb45-042a91e27b2e",
                            PermissionId = "11",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "7b02957c-a665-4237-86a1-838b2697ec8e",
                            PermissionId = "12",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "1002f143-de8b-40ee-bff2-d9e410b2966b",
                            PermissionId = "13",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "084a09e5-bd30-4ae0-aaa3-3d4278aefc2f",
                            PermissionId = "14",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "26e1aff4-dc16-4396-bf90-c19230b631b8",
                            PermissionId = "15",
                            RoleId = "HomeOwnerId"
                        },
                        new
                        {
                            RoleSystemPermissionId = "ed8e32a2-8171-42fe-8a47-7932a0925889",
                            PermissionId = "16",
                            RoleId = "HomeOwnerId"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Cameras.Entities.Camera", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Devices.Device");

                    b.Property<bool?>("IsExterior")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInterior")
                        .HasColumnType("bit");

                    b.ToTable("Cameras", (string)null);
                });

            modelBuilder.Entity("Homify.BusinessLogic.Lamps.Entities.Lamp", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Devices.Device");

                    b.ToTable("Lamps", (string)null);
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sensors.Entities.MovementSensor", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Devices.Device");

                    b.ToTable("MovementSensors", (string)null);
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sensors.Entities.WindowSensor", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Devices.Device");

                    b.ToTable("WindowSensors", (string)null);
                });

            modelBuilder.Entity("Homify.BusinessLogic.Admins.Entities.Admin", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Users.Entities.User");

                    b.ToTable("Admins", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "SeedAdminId",
                            CreatedAt = "16/11/2024",
                            Email = "admin@domain.com",
                            LastName = "LastName",
                            Name = "Admin",
                            Password = ".Popso212"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.CompanyOwners.Entities.CompanyOwner", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Users.Entities.User");

                    b.Property<bool>("IsIncomplete")
                        .HasColumnType("bit");

                    b.ToTable("CompanyOwners");

                    b.HasData(
                        new
                        {
                            Id = "SeedCompanyOwnerId",
                            CreatedAt = "16/11/2024",
                            Email = "companyowner@domain.com",
                            LastName = "LastName",
                            Name = "CompanyOwner",
                            Password = ".Popso212",
                            IsIncomplete = true
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeOwners.HomeOwner", b =>
                {
                    b.HasBaseType("Homify.BusinessLogic.Users.Entities.User");

                    b.ToTable("HomeOwners", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "SeedHomeOwnerId",
                            CreatedAt = "16/11/2024",
                            Email = "homeowner@domain.com",
                            LastName = "LastName",
                            Name = "Homeowner",
                            Password = ".Popso212",
                            ProfilePicture = "picture"
                        });
                });

            modelBuilder.Entity("Homify.BusinessLogic.Companies.Entities.Company", b =>
                {
                    b.HasOne("Homify.BusinessLogic.CompanyOwners.Entities.CompanyOwner", "Owner")
                        .WithOne("Company")
                        .HasForeignKey("Homify.BusinessLogic.Companies.Entities.Company", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Devices.Device", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Companies.Entities.Company", "Company")
                        .WithMany("Devices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeDevices.Entities.HomeDevice", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Devices.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homify.BusinessLogic.Homes.Entities.Home", "Home")
                        .WithMany("Devices")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Homify.BusinessLogic.Rooms.Entities.Room", "Room")
                        .WithMany("Devices")
                        .HasForeignKey("RoomId");

                    b.Navigation("Device");

                    b.Navigation("Home");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeUsers.HomeUser", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Homes.Entities.Home", "Home")
                        .WithMany("Members")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Homes.Entities.Home", b =>
                {
                    b.HasOne("Homify.BusinessLogic.HomeOwners.HomeOwner", "Owner")
                        .WithMany("Homes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Notifications.Entities.Notification", b =>
                {
                    b.HasOne("Homify.BusinessLogic.HomeDevices.Entities.HomeDevice", "Device")
                        .WithMany()
                        .HasForeignKey("HomeDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homify.BusinessLogic.HomeUsers.HomeUser", "HomeUser")
                        .WithMany()
                        .HasForeignKey("HomeUserId");

                    b.Navigation("Device");

                    b.Navigation("HomeUser");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Rooms.Entities.Room", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Homes.Entities.Home", "Home")
                        .WithMany("Rooms")
                        .HasForeignKey("HomeId");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sessions.Entities.Session", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Homify.BusinessLogic.UserRoles.Entities.UserRole", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Roles.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Homify.DataAccess.Contexts.HomifyDbContext+HomeUserHomePermission", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Permissions.HomePermissions.Entities.HomePermission", "HomePermission")
                        .WithMany()
                        .HasForeignKey("HomePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homify.BusinessLogic.HomeUsers.HomeUser", "HomeUser")
                        .WithMany()
                        .HasForeignKey("HomeUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomePermission");

                    b.Navigation("HomeUser");
                });

            modelBuilder.Entity("Homify.DataAccess.Contexts.HomifyDbContext+RoleSystemPermission", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Permissions.SystemPermissions.Entities.SystemPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");

                    b.HasOne("Homify.BusinessLogic.Roles.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Cameras.Entities.Camera", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.Cameras.Entities.Camera", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.Lamps.Entities.Lamp", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.Lamps.Entities.Lamp", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sensors.Entities.MovementSensor", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.Sensors.Entities.MovementSensor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.Sensors.Entities.WindowSensor", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.Sensors.Entities.WindowSensor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.Admins.Entities.Admin", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.Admins.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.CompanyOwners.Entities.CompanyOwner", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.CompanyOwners.Entities.CompanyOwner", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeOwners.HomeOwner", b =>
                {
                    b.HasOne("Homify.BusinessLogic.Users.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Homify.BusinessLogic.HomeOwners.HomeOwner", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Homify.BusinessLogic.Companies.Entities.Company", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Homes.Entities.Home", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Members");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Rooms.Entities.Room", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Homify.BusinessLogic.Users.Entities.User", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Homify.BusinessLogic.CompanyOwners.Entities.CompanyOwner", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("Homify.BusinessLogic.HomeOwners.HomeOwner", b =>
                {
                    b.Navigation("Homes");
                });
#pragma warning restore 612, 618
        }
    }
}
