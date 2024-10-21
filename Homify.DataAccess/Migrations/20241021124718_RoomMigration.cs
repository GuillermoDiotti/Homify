using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class RoomMigration : Migration
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
                ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sessions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Sessions_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
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
                Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Photos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PpalPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MovementDetection = table.Column<bool>(type: "bit", nullable: false),
                PeopleDetection = table.Column<bool>(type: "bit", nullable: false),
                WindowDetection = table.Column<bool>(type: "bit", nullable: false)
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
            name: "Rooms",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HomeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rooms", x => x.Id);
                table.ForeignKey(
                    name: "FK_Rooms_Homes_HomeId",
                    column: x => x.HomeId,
                    principalTable: "Homes",
                    principalColumn: "Id");
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

        migrationBuilder.CreateTable(
            name: "HomeDevices",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                HomeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Connected = table.Column<bool>(type: "bit", nullable: false),
                HardwareId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                RoomId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HomeDevices", x => x.Id);
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
                table.ForeignKey(
                    name: "FK_HomeDevices_Rooms_RoomId",
                    column: x => x.RoomId,
                    principalTable: "Rooms",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Notifications",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HomeDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                IsRead = table.Column<bool>(type: "bit", nullable: false),
                Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HomeUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Notifications", x => x.Id);
                table.ForeignKey(
                    name: "FK_Notifications_HomeDevices_HomeDeviceId",
                    column: x => x.HomeDeviceId,
                    principalTable: "HomeDevices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Notifications_HomeUsers_HomeUserId",
                    column: x => x.HomeUserId,
                    principalTable: "HomeUsers",
                    principalColumn: "Id");
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
                { "08764d78-27f6-42d0-967b-e238046f49f0", "16", "HomeOwnerId" },
                { "176fcc86-bb03-4d6b-adee-6e3d67249ff7", "5", "AdminId" },
                { "201bf294-9484-4f44-bcb9-ccc03eecb195", "8", "CompanyOwnerId" },
                { "25f914f1-ad51-43d9-9874-440d63e0a51d", "19", "HomeOwnerId" },
                { "27193b47-a305-440c-abfc-029f81109652", "11", "HomeOwnerId" },
                { "36d111f7-4d62-4b51-97b7-4601568411e4", "18", "HomeOwnerId" },
                { "4232f56f-217d-4e3c-b133-fbeb4ba8991c", "7", "CompanyOwnerId" },
                { "7ed015ed-84d0-471e-968b-b6bb6029fd99", "14", "HomeOwnerId" },
                { "844cdc2c-de12-4758-99ca-02633dcb9efe", "13", "HomeOwnerId" },
                { "917d161f-e54e-4f1f-b02c-d48444a733c4", "6", "CompanyOwnerId" },
                { "ab14c14e-7fa6-4fb9-9ed5-0e80d0b66d94", "15", "HomeOwnerId" },
                { "ba97f7e7-414d-48fd-a341-0a7a48805833", "3", "AdminId" },
                { "bd264121-97d4-4a05-94f0-df398fb0aee6", "17", "HomeOwnerId" },
                { "da2b9eea-0041-43e3-af78-fc4fa588dec7", "1", "AdminId" },
                { "dd3a4283-ea06-4ad0-b519-63d1ad2234a4", "10", "HomeOwnerId" },
                { "f1cbb313-22f7-4c00-86f9-9c2ed71ba51e", "9", "HomeOwnerId" },
                { "f3c61d5b-3e8c-4f39-bd36-5feecf54b860", "2", "AdminId" },
                { "f550f58b-54c6-4872-adfd-9035fdf4c2e0", "4", "AdminId" },
                { "fea3cee1-6a0b-4dcc-9da1-65316c7cc400", "12", "HomeOwnerId" }
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "ProfilePicture", "RoleId" },
            values: new object[,]
            {
                { "SeedAdminId", "21/10/2024", "admin@domain.com", "LastName", "Admin", ".Popso212", null, "AdminId" },
                { "SeedCompanyOwnerId", "21/10/2024", "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", null, "CompanyOwnerId" },
                { "SeedHomeOwnerId", "21/10/2024", "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "picture", "HomeOwnerId" }
            });

        migrationBuilder.InsertData(
            table: "Admins",
            column: "Id",
            value: "SeedAdminId");

        migrationBuilder.InsertData(
            table: "CompanyOwners",
            columns: new[] { "Id", "IsIncomplete" },
            values: new object[] { "SeedCompanyOwnerId", true });

        migrationBuilder.InsertData(
            table: "HomeOwners",
            column: "Id",
            value: "SeedHomeOwnerId");

        migrationBuilder.InsertData(
            table: "Sessions",
            columns: new[] { "Id", "AuthToken", "UserId" },
            values: new object[,]
            {
                { "SeedAdminSessionId", "SomeAdminToken123", "SeedAdminId" },
                { "SeedCompanyOwnerSessionId", "SomeCompanyOwnerToken123", "SeedCompanyOwnerId" },
                { "SeedHomeOwnerSessionId", "SomeHomeOwnerToken123", "SeedHomeOwnerId" }
            });

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
            name: "IX_HomeDevices_HomeId",
            table: "HomeDevices",
            column: "HomeId");

        migrationBuilder.CreateIndex(
            name: "IX_HomeDevices_RoomId",
            table: "HomeDevices",
            column: "RoomId");

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
            name: "IX_Notifications_HomeDeviceId",
            table: "Notifications",
            column: "HomeDeviceId");

        migrationBuilder.CreateIndex(
            name: "IX_Notifications_HomeUserId",
            table: "Notifications",
            column: "HomeUserId");

        migrationBuilder.CreateIndex(
            name: "IX_RoleSystemPermissions_PermissionId",
            table: "RoleSystemPermissions",
            column: "PermissionId");

        migrationBuilder.CreateIndex(
            name: "IX_RoleSystemPermissions_RoleId",
            table: "RoleSystemPermissions",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_Rooms_HomeId",
            table: "Rooms",
            column: "HomeId");

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
            name: "HomeDevices");

        migrationBuilder.DropTable(
            name: "HomeUsers");

        migrationBuilder.DropTable(
            name: "SystemPermissions");

        migrationBuilder.DropTable(
            name: "Devices");

        migrationBuilder.DropTable(
            name: "Rooms");

        migrationBuilder.DropTable(
            name: "Companies");

        migrationBuilder.DropTable(
            name: "Homes");

        migrationBuilder.DropTable(
            name: "CompanyOwners");

        migrationBuilder.DropTable(
            name: "HomeOwners");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Roles");
    }
}
