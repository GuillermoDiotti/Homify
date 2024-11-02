using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { "AdminId", "ADMINISTRATOR", null },
                    { "CompanyOwnerId", "COMPANYOWNER", null },
                    { "HomeOwnerId", "HOMEOWNER", null }
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
                    { "03ad2fe6-1507-4695-a56a-72c069b130d4", "17", "HomeOwnerId" },
                    { "15eb0103-71bf-4c61-b60d-0c1b27ac4a47", "11", "HomeOwnerId" },
                    { "231e51cd-ce64-445d-9f1f-1a1b9e9ee452", "18", "HomeOwnerId" },
                    { "38ed22ee-73ff-4902-9104-37aab0a3498f", "9", "HomeOwnerId" },
                    { "3a482be9-5c43-417c-a376-8a6862af2a1d", "8", "CompanyOwnerId" },
                    { "7e00431f-8113-48a9-a6ce-d8baea957aa2", "1", "AdminId" },
                    { "80d08fc6-059f-4470-a57d-fdc5c7f46155", "2", "AdminId" },
                    { "8d39ac80-9185-4b07-990e-ff46de2f6835", "5", "AdminId" },
                    { "93010585-450c-4fb7-8863-b9aff7a208d9", "16", "HomeOwnerId" },
                    { "a13f27f8-c609-438d-9f4c-ab2b1c0420d0", "14", "HomeOwnerId" },
                    { "a24fe266-78ef-4d31-92fd-c77e56dbb44e", "15", "HomeOwnerId" },
                    { "a51c131e-7a5c-4744-9aba-ea88f5748d6b", "13", "HomeOwnerId" },
                    { "a94cf882-0010-412b-835b-ded792f7fa9c", "3", "AdminId" },
                    { "b1885178-bc39-4361-a9bc-3b48454dea80", "12", "HomeOwnerId" },
                    { "b3395568-dcea-4dfe-b7f9-2edbe193dc72", "7", "CompanyOwnerId" },
                    { "b82f79c2-26f5-4ae9-90ed-55726be1c3a2", "6", "CompanyOwnerId" },
                    { "ba9198eb-7df8-4ccf-8054-10080ce31ff8", "4", "AdminId" },
                    { "c47909d3-fb55-4f2f-87a4-9234a0bc94f5", "19", "HomeOwnerId" },
                    { "c8bfe1c9-c9b2-4f42-9dc9-804e39f23679", "10", "HomeOwnerId" }
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
                    { "4431a628-9851-4c38-a216-e62c6ddcd475", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "a47c8454-9928-4197-b5f8-7c4423b597a1", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "c2c861d8-562a-4693-99c7-66d5e30ec390", "AdminId", "SeedAdminId" }
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
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

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
}
