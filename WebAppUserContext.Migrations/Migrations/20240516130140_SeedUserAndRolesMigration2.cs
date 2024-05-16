using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRolesMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4",
                column: "ConcurrencyStamp",
                value: "a5b4d84c-0602-4d85-9d8f-19838cd2240d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0",
                column: "ConcurrencyStamp",
                value: "a19e90f2-3003-41ed-ad6c-b5d71791f675");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b",
                column: "ConcurrencyStamp",
                value: "cf97e365-92fc-418c-80f3-5e9944c576c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b381bcef-7401-4acf-b370-0ff24590cb20", "AQAAAAIAAYagAAAAEMVBACfuKvUd99pY5RgPgA7DJs1zqsZBDxvmCJol1cUr88ORHVI9EfikrG6iRaxIew==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4",
                column: "ConcurrencyStamp",
                value: "3b2f6054-9659-442b-b273-dcf3ef8b49b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0",
                column: "ConcurrencyStamp",
                value: "298c8573-dd31-4339-91ce-d83720a34747");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b",
                column: "ConcurrencyStamp",
                value: "8c03a903-6e1e-4dbe-a521-ec6b4dc9a5e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff732daf-db3e-4435-a901-db2fba565f4b", "AQAAAAIAAYagAAAAEOOGNn+ECtU5ap54LQQ/qYhZxsYbHsoekZ+zo5QOH890X7V4BhAXo0oxOBVXM84Gwg==" });
        }
    }
}
