using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class DateFormat : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "02401a72-c0d9-49a2-8454-61ff1a6c1fee");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "024faf50-abc4-4146-9272-70a0ae68dec0");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0a488e5c-c2fd-43e1-a1b5-d055033f12fd");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0c49ec80-82b9-4bb2-8b42-4599ff2b50fb");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2bf6d901-b1e7-4f82-9082-a41379eef878");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2f0089a9-9d8f-488f-b4b1-0293fcba5cf9");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "300f6b32-cfac-428d-a018-20a41078c5d4");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "39a2ab93-500e-4402-b424-7b1b226a0fd8");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "553e4616-bff1-4b28-b128-e1147e97b279");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6145cf18-ee41-4306-aad9-38619d6d25ff");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6a157f9b-07a7-4e4d-b6d4-ac305c6e5492");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6a3950b7-c773-4281-b491-ff4e2bc03200");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6c53daea-ef6a-498f-ac32-a5ec2be12a1d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6dd98b4b-1e66-46cf-8557-caec32e62e18");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7520b7a3-0512-472f-81c7-95648a82ffe2");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7b10d490-5c89-4a39-b2d4-d0fab18990d7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "93bcca9c-015d-4aaa-8a5a-39b7b3647b79");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "acfc31ff-8821-409c-af38-a67e97542515");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "aead5c08-fb7b-4b9e-a7f3-018a7528d84b");

        migrationBuilder.AlterColumn<string>(
            name: "CreatedAt",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset");

        migrationBuilder.AlterColumn<string>(
            name: "Date",
            table: "Notifications",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset",
            oldNullable: true);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "07ff785e-b01a-42eb-b977-fcc4f616d1bd", "16", "HomeOwnerId" },
                { "26aacfe8-7e29-4b10-8454-ebec71aa0a1d", "11", "HomeOwnerId" },
                { "2a8adeb6-e419-406b-8b72-c33c2cc448b6", "17", "HomeOwnerId" },
                { "372859c6-5f86-43cc-ae7c-8d25c28c2d74", "18", "HomeOwnerId" },
                { "402879a4-045c-462f-879a-3cef9a290033", "15", "HomeOwnerId" },
                { "4ae13fc9-dbcd-4241-a3ab-3bda8c3fc7ff", "9", "HomeOwnerId" },
                { "4dec03c0-a429-4ae1-9a6d-b1c26ccc0445", "19", "HomeOwnerId" },
                { "5311ec22-6e91-4aa7-9d26-14f23700b668", "5", "AdminId" },
                { "5891ee88-b504-470f-9551-7911e098d605", "13", "HomeOwnerId" },
                { "5a2cd81f-605f-415f-b95f-8b282ea63f0e", "2", "AdminId" },
                { "75969ed5-0945-441d-972a-8753ee5debd1", "10", "HomeOwnerId" },
                { "77a304e0-5e34-4970-8cc5-ed3c22b729e7", "3", "AdminId" },
                { "97071e4e-07ed-43d0-a45d-d86c9018407b", "12", "HomeOwnerId" },
                { "a2992f18-7b60-41ae-a87c-993889c50e6d", "4", "AdminId" },
                { "b09c59d0-e601-4d93-a8df-ba5b4ab0868b", "6", "CompanyOwnerId" },
                { "c8b8e984-2fc3-4535-b1d5-3c971c1149df", "14", "HomeOwnerId" },
                { "d4814d3c-2750-4a0f-a2bf-30b20507e9cf", "1", "AdminId" },
                { "dc971f84-33e9-4efb-9127-14b10a67cdae", "8", "CompanyOwnerId" },
                { "ea61bbd4-2b4b-44f3-b03c-35804fec2777", "7", "CompanyOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: "18/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: "18/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: "18/10/2024");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "07ff785e-b01a-42eb-b977-fcc4f616d1bd");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "26aacfe8-7e29-4b10-8454-ebec71aa0a1d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2a8adeb6-e419-406b-8b72-c33c2cc448b6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "372859c6-5f86-43cc-ae7c-8d25c28c2d74");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "402879a4-045c-462f-879a-3cef9a290033");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4ae13fc9-dbcd-4241-a3ab-3bda8c3fc7ff");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4dec03c0-a429-4ae1-9a6d-b1c26ccc0445");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5311ec22-6e91-4aa7-9d26-14f23700b668");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5891ee88-b504-470f-9551-7911e098d605");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5a2cd81f-605f-415f-b95f-8b282ea63f0e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "75969ed5-0945-441d-972a-8753ee5debd1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "77a304e0-5e34-4970-8cc5-ed3c22b729e7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "97071e4e-07ed-43d0-a45d-d86c9018407b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a2992f18-7b60-41ae-a87c-993889c50e6d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b09c59d0-e601-4d93-a8df-ba5b4ab0868b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c8b8e984-2fc3-4535-b1d5-3c971c1149df");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "d4814d3c-2750-4a0f-a2bf-30b20507e9cf");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "dc971f84-33e9-4efb-9127-14b10a67cdae");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ea61bbd4-2b4b-44f3-b03c-35804fec2777");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "CreatedAt",
            table: "Users",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "Date",
            table: "Notifications",
            type: "datetimeoffset",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "02401a72-c0d9-49a2-8454-61ff1a6c1fee", "6", "CompanyOwnerId" },
                { "024faf50-abc4-4146-9272-70a0ae68dec0", "17", "HomeOwnerId" },
                { "0a488e5c-c2fd-43e1-a1b5-d055033f12fd", "16", "HomeOwnerId" },
                { "0c49ec80-82b9-4bb2-8b42-4599ff2b50fb", "7", "CompanyOwnerId" },
                { "2bf6d901-b1e7-4f82-9082-a41379eef878", "4", "AdminId" },
                { "2f0089a9-9d8f-488f-b4b1-0293fcba5cf9", "15", "HomeOwnerId" },
                { "300f6b32-cfac-428d-a018-20a41078c5d4", "2", "AdminId" },
                { "39a2ab93-500e-4402-b424-7b1b226a0fd8", "19", "HomeOwnerId" },
                { "553e4616-bff1-4b28-b128-e1147e97b279", "10", "HomeOwnerId" },
                { "6145cf18-ee41-4306-aad9-38619d6d25ff", "13", "HomeOwnerId" },
                { "6a157f9b-07a7-4e4d-b6d4-ac305c6e5492", "9", "HomeOwnerId" },
                { "6a3950b7-c773-4281-b491-ff4e2bc03200", "8", "CompanyOwnerId" },
                { "6c53daea-ef6a-498f-ac32-a5ec2be12a1d", "1", "AdminId" },
                { "6dd98b4b-1e66-46cf-8557-caec32e62e18", "5", "AdminId" },
                { "7520b7a3-0512-472f-81c7-95648a82ffe2", "12", "HomeOwnerId" },
                { "7b10d490-5c89-4a39-b2d4-d0fab18990d7", "3", "AdminId" },
                { "93bcca9c-015d-4aaa-8a5a-39b7b3647b79", "14", "HomeOwnerId" },
                { "acfc31ff-8821-409c-af38-a67e97542515", "18", "HomeOwnerId" },
                { "aead5c08-fb7b-4b9e-a7f3-018a7528d84b", "11", "HomeOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 5, 4, 57, 28, 465, DateTimeKind.Unspecified).AddTicks(4505), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 5, 4, 57, 28, 465, DateTimeKind.Unspecified).AddTicks(4525), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 5, 4, 57, 28, 465, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 0, 0, 0, 0)));
    }
}
