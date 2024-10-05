using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class HomeDeviceFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Devices_DeviceId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeDevices",
                table: "HomeDevices");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "008a9683-4d1a-4708-8a4c-b6369e701ccb");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "24eab801-1827-43b2-9190-2f916dea2cb0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3e98c87e-f8ca-4e73-90ad-a06984a25bee");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "43fca287-1e37-43c0-8ef1-7cd46a237e14");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5234a889-de30-417c-9ccf-9e5e052638d9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "64a83ff6-8126-45c7-9ac0-235861c6d5c3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6721140a-4f41-4451-a4f1-1e6db130201c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6e4909e2-f77c-4a9d-9464-f8b190a688b9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7abf535c-836f-4f36-a09f-c0a787ed45d9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "880623b8-7089-4efe-9687-8cc2dac3e3ef");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "abd55416-48ea-410a-bd0f-6be31951abcc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c2576a5b-3685-42c7-9f17-fb2d1401453b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c2838d8c-c4d0-4dcb-9a22-238b5cbd289f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c532bb80-86fe-42d1-9132-2ad74253e657");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ed01395e-bda7-4a46-9f44-59a8484d95c9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ee545e9b-4913-4d34-8388-f4f2ace4b0a1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f0c54312-1dd2-49c5-8419-e6685ca66e86");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f3dfc1e6-4289-431e-9c0d-b57c4299811b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f497fb9e-5140-4b02-9a3a-1095ca1e8e43");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "HomeDeviceId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "HomeDevices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeDevices",
                table: "HomeDevices",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "11cac00e-08b6-4787-a75e-771527609aa6", "11", "HomeOwnerId" },
                    { "22ee2841-cb66-4ba0-8414-717b70fe9a88", "6", "CompanyOwnerId" },
                    { "27997433-e84c-4c99-b2c8-cce2fb4647fa", "3", "AdminId" },
                    { "2cf74557-b66b-475a-ab38-95ce313c62bc", "13", "HomeOwnerId" },
                    { "30e1723b-7649-429b-82b2-2fd2ec70dec2", "16", "HomeOwnerId" },
                    { "441e9fc3-a436-48b1-99a7-9d9419993ff8", "19", "HomeOwnerId" },
                    { "483f51c3-d4c0-4404-8161-7c4d0946ffd1", "14", "HomeOwnerId" },
                    { "48cd7cbb-789f-4d1a-a3c2-f713c71a4584", "17", "HomeOwnerId" },
                    { "4a529e00-8985-4d80-a458-9bd9d7360dcd", "7", "CompanyOwnerId" },
                    { "92a5e3bd-dba5-49f3-bc52-56a44605fba6", "8", "CompanyOwnerId" },
                    { "937d4e3b-4d46-4af0-8d76-fe732cca357b", "4", "AdminId" },
                    { "97b276f3-8fa4-448d-a4d2-7fc10b616069", "1", "AdminId" },
                    { "a69cc11e-0c29-4712-a30e-dacb11cb59ff", "18", "HomeOwnerId" },
                    { "b1f25b0d-1ca0-4da0-8310-5293d62bd187", "5", "AdminId" },
                    { "bef0ff6e-0aff-4bfc-9997-d8872dcdcca0", "2", "AdminId" },
                    { "c1212017-7f21-4309-85fa-37c92255a7cb", "9", "HomeOwnerId" },
                    { "e5defa4d-8a49-4b1a-aa1d-25795aecc9aa", "15", "HomeOwnerId" },
                    { "e7595eb5-16c6-4b7c-9fef-c62ed0f95977", "10", "HomeOwnerId" },
                    { "f0be094e-0ed5-45e9-96db-fcaf502d1ae4", "12", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3660), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_HomeDeviceId",
                table: "Notifications",
                column: "HomeDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeDevices_HomeId",
                table: "HomeDevices",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_HomeDevices_HomeDeviceId",
                table: "Notifications",
                column: "HomeDeviceId",
                principalTable: "HomeDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_HomeDevices_HomeDeviceId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_HomeDeviceId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeDevices",
                table: "HomeDevices");

            migrationBuilder.DropIndex(
                name: "IX_HomeDevices_HomeId",
                table: "HomeDevices");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "11cac00e-08b6-4787-a75e-771527609aa6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "22ee2841-cb66-4ba0-8414-717b70fe9a88");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "27997433-e84c-4c99-b2c8-cce2fb4647fa");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2cf74557-b66b-475a-ab38-95ce313c62bc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "30e1723b-7649-429b-82b2-2fd2ec70dec2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "441e9fc3-a436-48b1-99a7-9d9419993ff8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "483f51c3-d4c0-4404-8161-7c4d0946ffd1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "48cd7cbb-789f-4d1a-a3c2-f713c71a4584");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4a529e00-8985-4d80-a458-9bd9d7360dcd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "92a5e3bd-dba5-49f3-bc52-56a44605fba6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "937d4e3b-4d46-4af0-8d76-fe732cca357b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "97b276f3-8fa4-448d-a4d2-7fc10b616069");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a69cc11e-0c29-4712-a30e-dacb11cb59ff");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b1f25b0d-1ca0-4da0-8310-5293d62bd187");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bef0ff6e-0aff-4bfc-9997-d8872dcdcca0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c1212017-7f21-4309-85fa-37c92255a7cb");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e5defa4d-8a49-4b1a-aa1d-25795aecc9aa");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e7595eb5-16c6-4b7c-9fef-c62ed0f95977");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f0be094e-0ed5-45e9-96db-fcaf502d1ae4");

            migrationBuilder.DropColumn(
                name: "HomeDeviceId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HomeDevices");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeDevices",
                table: "HomeDevices",
                columns: new[] { "HomeId", "DeviceId" });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "008a9683-4d1a-4708-8a4c-b6369e701ccb", "1", "AdminId" },
                    { "24eab801-1827-43b2-9190-2f916dea2cb0", "10", "HomeOwnerId" },
                    { "3e98c87e-f8ca-4e73-90ad-a06984a25bee", "9", "HomeOwnerId" },
                    { "43fca287-1e37-43c0-8ef1-7cd46a237e14", "19", "HomeOwnerId" },
                    { "5234a889-de30-417c-9ccf-9e5e052638d9", "17", "HomeOwnerId" },
                    { "64a83ff6-8126-45c7-9ac0-235861c6d5c3", "8", "CompanyOwnerId" },
                    { "6721140a-4f41-4451-a4f1-1e6db130201c", "3", "AdminId" },
                    { "6e4909e2-f77c-4a9d-9464-f8b190a688b9", "12", "HomeOwnerId" },
                    { "7abf535c-836f-4f36-a09f-c0a787ed45d9", "13", "HomeOwnerId" },
                    { "880623b8-7089-4efe-9687-8cc2dac3e3ef", "4", "AdminId" },
                    { "abd55416-48ea-410a-bd0f-6be31951abcc", "16", "HomeOwnerId" },
                    { "c2576a5b-3685-42c7-9f17-fb2d1401453b", "2", "AdminId" },
                    { "c2838d8c-c4d0-4dcb-9a22-238b5cbd289f", "14", "HomeOwnerId" },
                    { "c532bb80-86fe-42d1-9132-2ad74253e657", "5", "AdminId" },
                    { "ed01395e-bda7-4a46-9f44-59a8484d95c9", "6", "CompanyOwnerId" },
                    { "ee545e9b-4913-4d34-8388-f4f2ace4b0a1", "7", "CompanyOwnerId" },
                    { "f0c54312-1dd2-49c5-8419-e6685ca66e86", "18", "HomeOwnerId" },
                    { "f3dfc1e6-4289-431e-9c0d-b57c4299811b", "15", "HomeOwnerId" },
                    { "f497fb9e-5140-4b02-9a3a-1095ca1e8e43", "11", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Devices_DeviceId",
                table: "Notifications",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
