using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert roles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08dad08d-70d6-4056-b58f-63685eb1cfb4", null, "Formand", "FORMAND" },
                    { "51db585d-dfdb-4905-9c37-508424d019c0", null, "Bestyrelse", "BESTYRELSE" },
                    { "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b", null, "Medlem", "MEDLEM" }
                });

            // Insert user
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b9346c3-fa10-4f98-83ea-33c6b5711ad1", 0, "a9ebe513-11b5-4170-bbd3-2e2f137a37a7", "admin@admin.dk", true, false, null, "ADMIN@ADMIN.DK", "ADMIN@ADMIN.DK", "AQAAAAIAAYagAAAAEL93syMesFFeT0WemmklWaRvj/48NKYf0UwP5xkvTwGRsFpEcsZ/eQ7nqkvZP9ky3Q==", null, false, "", false, "admin@admin.dk" });

            // Assign roles to the user
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" }, // Medlem
                    { "51db585d-dfdb-4905-9c37-508424d019c0", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" }, // Bestyrelse
                    { "08dad08d-70d6-4056-b58f-63685eb1cfb4", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" }  // Formand
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete user roles
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "51db585d-dfdb-4905-9c37-508424d019c0", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08dad08d-70d6-4056-b58f-63685eb1cfb4", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" });

            // Delete user
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1");

            // Delete roles
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b");
        }
    }
}
