using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePermissionHomeUser");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "08009c28-d048-42ae-9461-8a04d69c5040");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "056e4c6c-0085-44ba-8df6-ca6997cf49f2");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "d392518f-319d-4a41-8cf6-aed4686bc5ef");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "163c07e8-fec1-4869-98f6-0c3e21ace5d1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "17de5a05-680d-4281-b1e5-6c3f2ada476b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2039e445-f008-43cf-b671-521d3db500b9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2a95feaa-64c6-45e0-997f-3ad6483677d5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4a15b122-278a-4235-abb2-713922803edf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5deafe6b-1645-4086-96fa-3a1c36a184ff");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6487a47f-83b8-4c33-bb97-8e927fdd97de");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6e0a404e-9894-4137-8ab5-fc2d7e3ea95a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cbd00d72-65d9-412c-b3dc-be7b5640f870");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0d7c2ff-eb29-49a2-b23b-af8047cb56e8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "da3a1ef0-aa01-4889-819d-cfd31ccea1b4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "dd1b84d8-5252-4035-89db-2c61e2c09eb4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "def82875-2929-47a7-b8eb-13c6b9d235a4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e20ed006-53e0-428a-9b98-e63c9b66be5d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e6072d73-6d74-4036-bce5-31e6bb4fe07e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "edc54d89-da46-4829-8194-b973f4592afe");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f9dbbde0-4095-4cbb-82f3-b8e8163f8740");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fa7aab64-e41e-41ab-975b-ec2a202d4bb0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fe08d917-5475-45ea-9e90-88ad039d560b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "056e4c6c-0085-44ba-8df6-ca6997cf49f2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "08009c28-d048-42ae-9461-8a04d69c5040");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d392518f-319d-4a41-8cf6-aed4686bc5ef");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "062d56b2-e1c3-4529-afd8-75ca680e0c71", "2", "AdminId" },
                    { "0a8653a3-a38c-483f-87e2-a96464adf7f2", "7", "CompanyOwnerId" },
                    { "2d9222b7-95ef-47c7-8135-3df1c222366b", "18", "HomeOwnerId" },
                    { "32e38b83-1afa-4f68-9d6d-ccba15ebdd8a", "5", "AdminId" },
                    { "35fd0788-7b3b-4dac-b448-9ab1ff04d701", "11", "HomeOwnerId" },
                    { "55c1ccb4-6671-4ef2-ae49-275db8a2aead", "4", "AdminId" },
                    { "57af0689-5185-4075-8e1e-a65d608b45f7", "13", "HomeOwnerId" },
                    { "72ae1eda-a994-4efc-b33d-2f44f4856c97", "10", "HomeOwnerId" },
                    { "7e4640f4-824a-495f-8d7b-3aa9ca2a6e20", "9", "HomeOwnerId" },
                    { "a4a67bef-76c3-4ed3-9946-087c2eb42fd5", "14", "HomeOwnerId" },
                    { "ad591748-c5c1-4f84-b296-302ad8e50bc7", "3", "AdminId" },
                    { "b0eb8b45-9682-443e-b025-c12f3101d6f4", "15", "HomeOwnerId" },
                    { "bcb4a19a-a4f4-4991-9067-6063eb1fe77c", "6", "CompanyOwnerId" },
                    { "c5bbef0d-9d58-48ca-8f30-e3e2e45da145", "17", "HomeOwnerId" },
                    { "cfd13073-6ed0-4d30-b099-2e663c0212bd", "19", "HomeOwnerId" },
                    { "d0586d23-c682-4ee5-adc4-c53d77a6c75c", "8", "CompanyOwnerId" },
                    { "e19e9ef4-effc-4e89-9577-93f57551ef92", "12", "HomeOwnerId" },
                    { "e97409ed-c058-4d86-9315-dace4af4bb07", "1", "AdminId" },
                    { "f925c638-1342-4830-88a0-b789c621b120", "16", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "591056d5-3d7c-45af-8cb8-20ec3e359d8c", new DateTimeOffset(new DateTime(2024, 10, 3, 14, 3, 5, 336, DateTimeKind.Unspecified).AddTicks(7240), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" },
                    { "937f924e-ca4b-45e7-8a5e-c03c660514f2", new DateTimeOffset(new DateTime(2024, 10, 3, 14, 3, 5, 336, DateTimeKind.Unspecified).AddTicks(7230), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "b6a3f006-0230-465a-92f7-d0d6ab4767e6", new DateTimeOffset(new DateTime(2024, 10, 3, 14, 3, 5, 336, DateTimeKind.Unspecified).AddTicks(7240), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "937f924e-ca4b-45e7-8a5e-c03c660514f2");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "b6a3f006-0230-465a-92f7-d0d6ab4767e6", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "591056d5-3d7c-45af-8cb8-20ec3e359d8c", "picture" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "937f924e-ca4b-45e7-8a5e-c03c660514f2");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "b6a3f006-0230-465a-92f7-d0d6ab4767e6");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "591056d5-3d7c-45af-8cb8-20ec3e359d8c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "062d56b2-e1c3-4529-afd8-75ca680e0c71");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0a8653a3-a38c-483f-87e2-a96464adf7f2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2d9222b7-95ef-47c7-8135-3df1c222366b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "32e38b83-1afa-4f68-9d6d-ccba15ebdd8a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "35fd0788-7b3b-4dac-b448-9ab1ff04d701");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "55c1ccb4-6671-4ef2-ae49-275db8a2aead");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "57af0689-5185-4075-8e1e-a65d608b45f7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "72ae1eda-a994-4efc-b33d-2f44f4856c97");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7e4640f4-824a-495f-8d7b-3aa9ca2a6e20");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a4a67bef-76c3-4ed3-9946-087c2eb42fd5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ad591748-c5c1-4f84-b296-302ad8e50bc7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b0eb8b45-9682-443e-b025-c12f3101d6f4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bcb4a19a-a4f4-4991-9067-6063eb1fe77c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c5bbef0d-9d58-48ca-8f30-e3e2e45da145");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cfd13073-6ed0-4d30-b099-2e663c0212bd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0586d23-c682-4ee5-adc4-c53d77a6c75c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e19e9ef4-effc-4e89-9577-93f57551ef92");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e97409ed-c058-4d86-9315-dace4af4bb07");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f925c638-1342-4830-88a0-b789c621b120");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "591056d5-3d7c-45af-8cb8-20ec3e359d8c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "937f924e-ca4b-45e7-8a5e-c03c660514f2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b6a3f006-0230-465a-92f7-d0d6ab4767e6");

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
                name: "IX_HomePermissionHomeUser_PermissionsId",
                table: "HomePermissionHomeUser",
                column: "PermissionsId");
        }
    }
}
