using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
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
                CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
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
            name: "UserRoles",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserRoles_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_UserRoles_Users_UserId",
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
                CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                { "1", "AddDevices" },
                { "2", "ListDevices" },
                { "3", "ChangeDeviceName" }
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
                { "9", "homes-Create" },
                { "20", "companies-RegisterLamp" },
                { "21", "companies-RegisterMovementSensor" },
                { "22", "companies-ImportDevices" }
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "ProfilePicture" },
            values: new object[,]
            {
                { "SeedAdminId", "02/11/2024", "admin@domain.com", "LastName", "Admin", ".Popso212", null },
                { "SeedCompanyOwnerId", "02/11/2024", "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", null },
                { "SeedHomeOwnerId", "02/11/2024", "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "picture" }
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
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "10a7547f-b03c-46b2-b787-f84a8efbdc6c", "17", "HomeOwnerId" },
                { "1cd49e3f-a0f8-4c56-93cd-cb7bac611e43", "2", "AdminId" },
                { "38fdbbdb-d1bb-478f-9a3a-2c1a44975f15", "6", "CompanyOwnerId" },
                { "39b07b3c-1cdb-4a22-8d86-e90d0e3200d6", "4", "AdminId" },
                { "3d77aa9d-5789-430e-ab6b-3ff270b05c19", "13", "HomeOwnerId" },
                { "4b501aff-0a1e-4d52-a163-cdb7833c5792", "1", "AdminId" },
                { "5d394608-2819-4a50-85d0-883c8be16ba0", "12", "HomeOwnerId" },
                { "6572966b-630e-432c-8212-86d8e2ab61cc", "16", "HomeOwnerId" },
                { "717d001e-56ac-446f-a02e-9058a1496b57", "3", "AdminId" },
                { "73788f33-47b7-4cf9-8b46-188b750890db", "11", "HomeOwnerId" },
                { "813aefdf-d608-4aee-a0a8-13c904e6058a", "14", "HomeOwnerId" },
                { "8cc003a6-18db-4b5a-bc18-b1a5e60b9fbc", "19", "HomeOwnerId" },
                { "905d668b-8a90-4308-a20a-5023a2a65f7f", "5", "AdminId" },
                { "a3af3e88-acc8-491c-8c5d-1c475faa6aca", "15", "HomeOwnerId" },
                { "a5395f3e-b5e4-456b-8417-532bba2962fc", "10", "HomeOwnerId" },
                { "bab54740-89b7-4fd7-9c5a-77d3158c1c29", "18", "HomeOwnerId" },
                { "eaf017eb-6d0c-41d4-90fc-b50b5a2401e5", "9", "HomeOwnerId" },
                { "f2f668b8-45e0-4916-aefa-16648a88c50f", "8", "CompanyOwnerId" },
                { "f4cc5867-d7b5-413b-8017-b8c65d003b23", "7", "CompanyOwnerId" },
                { "f4cc5867-d7b5-413b-8017-b8c65d003b24", "20", "CompanyOwnerId" },
                { "f4cc5867-d7b5-413b-8017-b8c65d003b25", "21", "CompanyOwnerId" },
                { "f4cc5867-d7b5-413b-8017-b8c65d003b26", "22", "CompanyOwnerId" }
            });

        migrationBuilder.InsertData(
            table: "Sessions",
            columns: new[] { "Id", "AuthToken", "UserId" },
            values: new object[,]
            {
                { "SeedAdminSessionId", "SomeAdminToken123", "SeedAdminId" },
                { "SeedCompanyOwnerSessionId", "SomeCompanyOwnerToken123", "SeedCompanyOwnerId" },
                { "SeedHomeOwnerSessionId", "SomeHomeOwnerToken123", "SeedHomeOwnerId" }
            });

        migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "Id", "RoleId", "UserId" },
            values: new object[,]
            {
                { "3cd380a2-6d7a-4bd0-b06c-16cdcb2cdf84", "HomeOwnerId", "SeedHomeOwnerId" },
                { "a887b2ee-f561-4d7d-aff1-1af61e1c4e5d", "CompanyOwnerId", "SeedCompanyOwnerId" },
                { "ad44ab69-77c1-4e11-9ba9-955c43496b55", "AdminId", "SeedAdminId" }
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
            name: "IX_UserRoles_RoleId",
            table: "UserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRoles_UserId",
            table: "UserRoles",
            column: "UserId");
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
            name: "UserRoles");

        migrationBuilder.DropTable(
            name: "HomePermission");

        migrationBuilder.DropTable(
            name: "HomeDevices");

        migrationBuilder.DropTable(
            name: "HomeUsers");

        migrationBuilder.DropTable(
            name: "SystemPermissions");

        migrationBuilder.DropTable(
            name: "Roles");

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
    }
}
