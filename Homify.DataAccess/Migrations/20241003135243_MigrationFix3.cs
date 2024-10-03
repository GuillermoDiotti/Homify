using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemPermissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleSystemPermissions",
                columns: table => new
                {
                    RoleSystemPermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSystemPermissions", x => x.RoleSystemPermissionId);
                    table.ForeignKey(
                        name: "FK_RoleSystemPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleSystemPermissions_SystemPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "SystemPermissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOwners",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsIncomplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOwners_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeOwners",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeOwners_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homes_HomeOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "HomeOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PpalPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsNotificable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeUsers_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HomeUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsExterior = table.Column<bool>(type: "bit", nullable: false),
                    IsInterior = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeDevices",
                columns: table => new
                {
                    HomeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Connected = table.Column<bool>(type: "bit", nullable: false),
                    HardwareId = table.Column<int>(type: "int", nullable: false),
                    MovementDetection = table.Column<bool>(type: "bit", nullable: false),
                    PeopleDetection = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeDevices", x => new { x.HomeId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_HomeDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeDevices_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomePermissionHomeUser",
                columns: table => new
                {
                    HomeUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePermissionHomeUser", x => new { x.HomeUsersId, x.PermissionsId });
                    table.ForeignKey(
                        name: "FK_HomePermissionHomeUser_HomePermission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "HomePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomePermissionHomeUser_HomeUsers_HomeUsersId",
                        column: x => x.HomeUsersId,
                        principalTable: "HomeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeUserHomePermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomePermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeUserHomePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeUserHomePermission_HomePermission_HomePermissionId",
                        column: x => x.HomePermissionId,
                        principalTable: "HomePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeUserHomePermission_HomeUsers_HomeUserId",
                        column: x => x.HomeUserId,
                        principalTable: "HomeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HomePermission",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { "1", "HomeOwner" },
                    { "2", "AddDevices" },
                    { "3", "ListDevices" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "AdminId", "ADMINISTRATOR" },
                    { "CompanyOwnerId", "COMPANYOWNER" },
                    { "HomeOwnerId", "HOMEOWNER" }
                });

            migrationBuilder.InsertData(
                table: "SystemPermissions",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { "1", "admins-Create" },
                    { "10", "homes-UpdateMembersList" },
                    { "11", "homes-UpdateHomeDevice" },
                    { "12", "homes-ObtainMembers" },
                    { "13", "homes-ObtainHomeDevices" },
                    { "14", "homes-NotificatedMembers" },
                    { "15", "notifications-ObtainNotifications" },
                    { "16", "notifications-UpdateNotification" },
                    { "17", "devices-ViewRegistered" },
                    { "18", "companies-ViewSupported" },
                    { "19", "notifications-Create" },
                    { "2", "admins-Delete" },
                    { "3", "admins-AllAccounts" },
                    { "4", "company-owners-Create" },
                    { "5", "homes-ObtainCompanies" },
                    { "6", "companies-Create" },
                    { "7", "devices-RegisterCamera" },
                    { "8", "companies-RegisterSensor" },
                    { "9", "homes-Create" }
                });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "163c07e8-fec1-4869-98f6-0c3e21ace5d1", "14", "HomeOwnerId" },
                    { "17de5a05-680d-4281-b1e5-6c3f2ada476b", "4", "AdminId" },
                    { "2039e445-f008-43cf-b671-521d3db500b9", "5", "AdminId" },
                    { "2a95feaa-64c6-45e0-997f-3ad6483677d5", "15", "HomeOwnerId" },
                    { "4a15b122-278a-4235-abb2-713922803edf", "16", "HomeOwnerId" },
                    { "5deafe6b-1645-4086-96fa-3a1c36a184ff", "12", "HomeOwnerId" },
                    { "6487a47f-83b8-4c33-bb97-8e927fdd97de", "19", "HomeOwnerId" },
                    { "6e0a404e-9894-4137-8ab5-fc2d7e3ea95a", "11", "HomeOwnerId" },
                    { "cbd00d72-65d9-412c-b3dc-be7b5640f870", "6", "CompanyOwnerId" },
                    { "d0d7c2ff-eb29-49a2-b23b-af8047cb56e8", "2", "AdminId" },
                    { "da3a1ef0-aa01-4889-819d-cfd31ccea1b4", "18", "HomeOwnerId" },
                    { "dd1b84d8-5252-4035-89db-2c61e2c09eb4", "7", "CompanyOwnerId" },
                    { "def82875-2929-47a7-b8eb-13c6b9d235a4", "1", "AdminId" },
                    { "e20ed006-53e0-428a-9b98-e63c9b66be5d", "13", "HomeOwnerId" },
                    { "e6072d73-6d74-4036-bce5-31e6bb4fe07e", "3", "AdminId" },
                    { "edc54d89-da46-4829-8194-b973f4592afe", "10", "HomeOwnerId" },
                    { "f9dbbde0-4095-4cbb-82f3-b8e8163f8740", "8", "CompanyOwnerId" },
                    { "fa7aab64-e41e-41ab-975b-ec2a202d4bb0", "17", "HomeOwnerId" },
                    { "fe08d917-5475-45ea-9e90-88ad039d560b", "9", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "056e4c6c-0085-44ba-8df6-ca6997cf49f2", new DateTimeOffset(new DateTime(2024, 10, 3, 13, 52, 42, 792, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" },
                    { "08009c28-d048-42ae-9461-8a04d69c5040", new DateTimeOffset(new DateTime(2024, 10, 3, 13, 52, 42, 792, DateTimeKind.Unspecified).AddTicks(7570), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "d392518f-319d-4a41-8cf6-aed4686bc5ef", new DateTimeOffset(new DateTime(2024, 10, 3, 13, 52, 42, 792, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "08009c28-d048-42ae-9461-8a04d69c5040");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "056e4c6c-0085-44ba-8df6-ca6997cf49f2", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "d392518f-319d-4a41-8cf6-aed4686bc5ef", "picture" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CompanyId",
                table: "Devices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeDevices_DeviceId",
                table: "HomeDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePermissionHomeUser_PermissionsId",
                table: "HomePermissionHomeUser",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_OwnerId",
                table: "Homes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUserHomePermission_HomePermissionId",
                table: "HomeUserHomePermission",
                column: "HomePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUserHomePermission_HomeUserId",
                table: "HomeUserHomePermission",
                column: "HomeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUsers_HomeId",
                table: "HomeUsers",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeUsers_UserId",
                table: "HomeUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSystemPermissions_PermissionId",
                table: "RoleSystemPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSystemPermissions_RoleId",
                table: "RoleSystemPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "HomeDevices");

            migrationBuilder.DropTable(
                name: "HomePermissionHomeUser");

            migrationBuilder.DropTable(
                name: "HomeUserHomePermission");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RoleSystemPermissions");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "HomePermission");

            migrationBuilder.DropTable(
                name: "HomeUsers");

            migrationBuilder.DropTable(
                name: "SystemPermissions");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "HomeOwners");

            migrationBuilder.DropTable(
                name: "CompanyOwners");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
