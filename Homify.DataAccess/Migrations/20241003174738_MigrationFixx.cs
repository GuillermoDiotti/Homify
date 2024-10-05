using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]

    /// <inheritdoc />
    public partial class MigrationFixx : Migration
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
                    HardwareId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { "0f9e7c8d-9b63-40c5-b192-20aef9ec2e40", "1", "AdminId" },
                    { "14a15f97-c8d2-485d-bff9-9da35686c943", "13", "HomeOwnerId" },
                    { "182c2988-c26b-49d7-ade1-6a8b683afb9b", "16", "HomeOwnerId" },
                    { "1d724d49-75f2-4cd3-8a43-392ef102dc3d", "17", "HomeOwnerId" },
                    { "31ef4463-eeda-4f40-9022-e56684e5796b", "15", "HomeOwnerId" },
                    { "3835da06-2337-486e-97e5-86a2e1574a13", "4", "AdminId" },
                    { "3e7c2678-2baf-4f52-824d-29a7861a8d1e", "19", "HomeOwnerId" },
                    { "40ddbab5-508b-4c5f-b91a-9e26013185b5", "12", "HomeOwnerId" },
                    { "43dc8474-4b54-4256-aea8-c806e48029ef", "10", "HomeOwnerId" },
                    { "4aa7f886-f069-4748-af73-a333ece2da6a", "3", "AdminId" },
                    { "523712b1-3869-4449-a507-4a25f119a773", "9", "HomeOwnerId" },
                    { "59a8bbc5-fa4c-4bba-aef2-539c6bff19f5", "5", "AdminId" },
                    { "6c3da7ca-135b-4048-9c4c-53beacadd3e2", "7", "CompanyOwnerId" },
                    { "8c0ee6c7-67d5-4622-82d0-2b25fe625b11", "18", "HomeOwnerId" },
                    { "91d16098-f508-4c92-aa30-c5787c58f62e", "14", "HomeOwnerId" },
                    { "cdb331b3-c3d2-4e15-8713-aa50308ebb28", "2", "AdminId" },
                    { "d0694415-9327-42e7-b754-8c1b8e1037e0", "11", "HomeOwnerId" },
                    { "d3ff52f6-1410-4fda-887f-341b49248482", "6", "CompanyOwnerId" },
                    { "fcdab3d8-eb0a-4c5e-aad7-63d6b9887207", "8", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "9dabf09e-60cb-43ba-b5c6-742604b52f88", new DateTimeOffset(new DateTime(2024, 10, 3, 17, 47, 37, 713, DateTimeKind.Unspecified).AddTicks(4395), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" },
                    { "a36d69f4-96a9-4a0d-ad4f-ab108bf34e7e", new DateTimeOffset(new DateTime(2024, 10, 3, 17, 47, 37, 713, DateTimeKind.Unspecified).AddTicks(4381), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "b0bd3b90-db41-4f35-bae3-5b0e97c653f4", new DateTimeOffset(new DateTime(2024, 10, 3, 17, 47, 37, 713, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "a36d69f4-96a9-4a0d-ad4f-ab108bf34e7e");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "b0bd3b90-db41-4f35-bae3-5b0e97c653f4", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "9dabf09e-60cb-43ba-b5c6-742604b52f88", "picture" });

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
