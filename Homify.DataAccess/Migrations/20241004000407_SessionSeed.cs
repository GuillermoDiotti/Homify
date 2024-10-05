using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]

    /// <inheritdoc />
    public partial class SessionSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "a36d69f4-96a9-4a0d-ad4f-ab108bf34e7e");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "b0bd3b90-db41-4f35-bae3-5b0e97c653f4");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "9dabf09e-60cb-43ba-b5c6-742604b52f88");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0f9e7c8d-9b63-40c5-b192-20aef9ec2e40");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "14a15f97-c8d2-485d-bff9-9da35686c943");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "182c2988-c26b-49d7-ade1-6a8b683afb9b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1d724d49-75f2-4cd3-8a43-392ef102dc3d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "31ef4463-eeda-4f40-9022-e56684e5796b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3835da06-2337-486e-97e5-86a2e1574a13");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3e7c2678-2baf-4f52-824d-29a7861a8d1e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "40ddbab5-508b-4c5f-b91a-9e26013185b5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "43dc8474-4b54-4256-aea8-c806e48029ef");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4aa7f886-f069-4748-af73-a333ece2da6a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "523712b1-3869-4449-a507-4a25f119a773");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "59a8bbc5-fa4c-4bba-aef2-539c6bff19f5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6c3da7ca-135b-4048-9c4c-53beacadd3e2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8c0ee6c7-67d5-4622-82d0-2b25fe625b11");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "91d16098-f508-4c92-aa30-c5787c58f62e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cdb331b3-c3d2-4e15-8713-aa50308ebb28");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0694415-9327-42e7-b754-8c1b8e1037e0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d3ff52f6-1410-4fda-887f-341b49248482");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fcdab3d8-eb0a-4c5e-aad7-63d6b9887207");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9dabf09e-60cb-43ba-b5c6-742604b52f88");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a36d69f4-96a9-4a0d-ad4f-ab108bf34e7e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b0bd3b90-db41-4f35-bae3-5b0e97c653f4");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "SeedAdminId", new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(235), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "SeedCompanyOwnerId", new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(257), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" },
                    { "SeedHomeOwnerId", new DateTimeOffset(new DateTime(2024, 10, 4, 0, 4, 6, 947, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" }
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
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "SeedHomeOwnerId", "picture" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "AuthToken", "UserId" },
                values: new object[,]
                {
                    { "SeedAdminSessionId", "SomeAdminToken123", "SeedAdminId" },
                    { "SeedCompanyOwnerSessionId", "SomeCompanyOwnerToken123", "SeedCompanyOwnerId" },
                    { "SeedHomeOwnerSessionId", "SomeHomeOwnerToken123", "SeedHomeOwnerId" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "SeedAdminId");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId");

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

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: "SeedAdminSessionId");

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerSessionId");

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerSessionId");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
