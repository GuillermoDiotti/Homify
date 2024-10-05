using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]

    /// <inheritdoc />
    public partial class HomeDeviceProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "01802eeb-dd64-4641-9713-226464c5635e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "01fc3f25-c78e-4909-ad05-f4932ac0fba8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2128e238-ed5b-4636-9036-53f9eef4a633");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "244a42a3-e639-405e-921d-4f915fe8372e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "29feebf1-95d1-40f3-9d9c-b1665ee285ed");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "373c66dd-1fc6-4643-8745-730a0503f96f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "39f77143-d084-408e-993f-7a8e7f5eda98");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7f954dca-9016-4eb7-9965-eaafc394351a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8b73e6ff-91e2-41f8-b511-74f9f5ce7943");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "997f12d1-34c1-4e64-ac77-063785a87dac");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "99d8d834-8b01-4892-aae8-67dd105ae36f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ba7b5047-970f-4a8c-a99f-8a3203914442");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bd6ef21d-bcac-4ff5-97f3-3b3045ff40ca");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c250e55e-77cb-40e6-b3fd-1364c6470d69");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c404b72f-9eeb-4f84-b47e-ad6db9b51862");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "db625545-fda1-49c4-a40e-1705f6049c61");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e18f1578-22d4-4d03-911e-7d301512aba1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fc74f1a2-3537-475d-89b3-0cb97dc535d4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ffa890ed-480c-4537-96b8-971335915cf3");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Devices");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HomeDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "00823fba-5f2a-4e7e-a8a0-c033971b15b6", "1", "AdminId" },
                    { "0cf69691-df49-4e6f-8a89-a596a3535b1d", "8", "CompanyOwnerId" },
                    { "190041dd-6fd3-48db-84d9-4d22774b516d", "10", "HomeOwnerId" },
                    { "197f7064-4d71-48ca-b27b-a9ce94b45fec", "5", "AdminId" },
                    { "2f16081e-f6ab-420d-999c-5141bd2de04e", "15", "HomeOwnerId" },
                    { "423ba779-8355-467d-a7c7-a5d9c5b2dd70", "14", "HomeOwnerId" },
                    { "425b3b3a-ac99-42b5-9bec-52d397a6c62f", "11", "HomeOwnerId" },
                    { "4bfeb589-31ce-4fec-a2ee-ac147dcdbc77", "12", "HomeOwnerId" },
                    { "54f02ee2-35c5-4a23-9d5c-a065f8f4e593", "3", "AdminId" },
                    { "56c26fa4-86ed-4d94-ac32-5a4c789091ff", "6", "CompanyOwnerId" },
                    { "57118001-e796-4696-b336-8bee1a51d75a", "2", "AdminId" },
                    { "a43ecf43-97a6-44c9-9283-846809c7e58f", "16", "HomeOwnerId" },
                    { "a6c6c91c-27c5-481b-a63f-e486640da033", "9", "HomeOwnerId" },
                    { "acf95e51-3b84-47a3-9245-44eeba5820ba", "18", "HomeOwnerId" },
                    { "b3ffb3cb-664e-4d1f-bae1-ee2dd1f19c77", "13", "HomeOwnerId" },
                    { "bcaa8e26-478f-4a91-87c1-2b2ab418c63d", "19", "HomeOwnerId" },
                    { "d31c4066-1adf-4f45-b9cd-ae691566e698", "17", "HomeOwnerId" },
                    { "d48a8027-4763-47a1-9b96-2e9516d2c09f", "7", "CompanyOwnerId" },
                    { "fcfa4360-1625-45cf-8ac6-f5f3278af290", "4", "AdminId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 38, 21, 12, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 38, 21, 12, DateTimeKind.Unspecified).AddTicks(420), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 38, 21, 12, DateTimeKind.Unspecified).AddTicks(412), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "00823fba-5f2a-4e7e-a8a0-c033971b15b6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0cf69691-df49-4e6f-8a89-a596a3535b1d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "190041dd-6fd3-48db-84d9-4d22774b516d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "197f7064-4d71-48ca-b27b-a9ce94b45fec");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2f16081e-f6ab-420d-999c-5141bd2de04e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "423ba779-8355-467d-a7c7-a5d9c5b2dd70");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "425b3b3a-ac99-42b5-9bec-52d397a6c62f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4bfeb589-31ce-4fec-a2ee-ac147dcdbc77");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "54f02ee2-35c5-4a23-9d5c-a065f8f4e593");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "56c26fa4-86ed-4d94-ac32-5a4c789091ff");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "57118001-e796-4696-b336-8bee1a51d75a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a43ecf43-97a6-44c9-9283-846809c7e58f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a6c6c91c-27c5-481b-a63f-e486640da033");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "acf95e51-3b84-47a3-9245-44eeba5820ba");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b3ffb3cb-664e-4d1f-bae1-ee2dd1f19c77");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bcaa8e26-478f-4a91-87c1-2b2ab418c63d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d31c4066-1adf-4f45-b9cd-ae691566e698");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d48a8027-4763-47a1-9b96-2e9516d2c09f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fcfa4360-1625-45cf-8ac6-f5f3278af290");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HomeDevices");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "01802eeb-dd64-4641-9713-226464c5635e", "16", "HomeOwnerId" },
                    { "01fc3f25-c78e-4909-ad05-f4932ac0fba8", "17", "HomeOwnerId" },
                    { "2128e238-ed5b-4636-9036-53f9eef4a633", "10", "HomeOwnerId" },
                    { "244a42a3-e639-405e-921d-4f915fe8372e", "12", "HomeOwnerId" },
                    { "29feebf1-95d1-40f3-9d9c-b1665ee285ed", "18", "HomeOwnerId" },
                    { "373c66dd-1fc6-4643-8745-730a0503f96f", "1", "AdminId" },
                    { "39f77143-d084-408e-993f-7a8e7f5eda98", "3", "AdminId" },
                    { "7f954dca-9016-4eb7-9965-eaafc394351a", "8", "CompanyOwnerId" },
                    { "8b73e6ff-91e2-41f8-b511-74f9f5ce7943", "19", "HomeOwnerId" },
                    { "997f12d1-34c1-4e64-ac77-063785a87dac", "2", "AdminId" },
                    { "99d8d834-8b01-4892-aae8-67dd105ae36f", "6", "CompanyOwnerId" },
                    { "ba7b5047-970f-4a8c-a99f-8a3203914442", "5", "AdminId" },
                    { "bd6ef21d-bcac-4ff5-97f3-3b3045ff40ca", "7", "CompanyOwnerId" },
                    { "c250e55e-77cb-40e6-b3fd-1364c6470d69", "4", "AdminId" },
                    { "c404b72f-9eeb-4f84-b47e-ad6db9b51862", "15", "HomeOwnerId" },
                    { "db625545-fda1-49c4-a40e-1705f6049c61", "14", "HomeOwnerId" },
                    { "e18f1578-22d4-4d03-911e-7d301512aba1", "11", "HomeOwnerId" },
                    { "fc74f1a2-3537-475d-89b3-0cb97dc535d4", "13", "HomeOwnerId" },
                    { "ffa890ed-480c-4537-96b8-971335915cf3", "9", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8659), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
