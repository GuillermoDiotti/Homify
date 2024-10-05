using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NotificationDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_HomeUsers_HomeUserId",
                table: "Notifications");

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

            migrationBuilder.RenameColumn(
                name: "DetectedUserId",
                table: "Notifications",
                newName: "Detail");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_HomeUsers_HomeUserId",
                table: "Notifications",
                column: "HomeUserId",
                principalTable: "HomeUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_HomeUsers_HomeUserId",
                table: "Notifications");

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

            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Notifications",
                newName: "DetectedUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_HomeUsers_HomeUserId",
                table: "Notifications",
                column: "HomeUserId",
                principalTable: "HomeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
