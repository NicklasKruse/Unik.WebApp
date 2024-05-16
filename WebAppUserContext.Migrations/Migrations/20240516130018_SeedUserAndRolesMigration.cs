using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1173e65c-2f7d-49b5-a957-fb96086aea7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7748db3b-69b0-478e-a840-0a63d54c4ac7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a96f5ba3-dc0e-4149-b779-616f89380579");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4a358713-6663-4fcb-9975-09cba0b4c42b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "4a358713-6663-4fcb-9975-09cba0b4c42b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "4a358713-6663-4fcb-9975-09cba0b4c42b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a358713-6663-4fcb-9975-09cba0b4c42b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08dad08d-70d6-4056-b58f-63685eb1cfb4", "3b2f6054-9659-442b-b273-dcf3ef8b49b6", "Formand", "FORMAND" },
                    { "51db585d-dfdb-4905-9c37-508424d019c0", "298c8573-dd31-4339-91ce-d83720a34747", "Bestyrelse", "BESTYRELSE" },
                    { "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b", "8c03a903-6e1e-4dbe-a521-ec6b4dc9a5e8", "Medlem", "MEDLEM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b9346c3-fa10-4f98-83ea-33c6b5711ad1", 0, "ff732daf-db3e-4435-a901-db2fba565f4b", "admin@admin.dk", true, false, null, "ADMIN@ADMIN.DK", "ADMIN@ADMIN.DK", "AQAAAAIAAYagAAAAEOOGNn+ECtU5ap54LQQ/qYhZxsYbHsoekZ+zo5QOH890X7V4BhAXo0oxOBVXM84Gwg==", null, false, "", false, "admin@admin.dk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "08dad08d-70d6-4056-b58f-63685eb1cfb4", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08dad08d-70d6-4056-b58f-63685eb1cfb4", "1b9346c3-fa10-4f98-83ea-33c6b5711ad1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1173e65c-2f7d-49b5-a957-fb96086aea7c", "Formand", "FORMAND" },
                    { "7748db3b-69b0-478e-a840-0a63d54c4ac7", "Bestyrelse", "BESTYRELSE" },
                    { "a96f5ba3-dc0e-4149-b779-616f89380579", "Medlem", "MEDLEM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a358713-6663-4fcb-9975-09cba0b4c42b", 0, "4c1de125-8340-490d-a0f2-f41af83eaf4f", "admin@admin.dk", true, false, null, "ADMIN@ADMIN.DK", "ADMIN@ADMIN.DK", "AQAAAAIAAYagAAAAEHKdJsnnGkocC1UAOQPxftiazSm8Dq+yT4zi4VaH15fSQZ+FYV2hHM46peRBnCzcXQ==", null, false, "", false, "admin@admin.dk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "4a358713-6663-4fcb-9975-09cba0b4c42b" },
                    { "2", "4a358713-6663-4fcb-9975-09cba0b4c42b" },
                    { "3", "4a358713-6663-4fcb-9975-09cba0b4c42b" }
                });
        }
    }
}
