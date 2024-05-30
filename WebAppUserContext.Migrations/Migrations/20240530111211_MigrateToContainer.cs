using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class MigrateToContainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4",
                column: "ConcurrencyStamp",
                value: "6ed6ff5f-4179-4fc6-b140-8e97dc633a97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0",
                column: "ConcurrencyStamp",
                value: "d10253f9-3e06-4b77-a9c1-fc17f37746f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b",
                column: "ConcurrencyStamp",
                value: "6450a297-340f-4f21-98b3-fff62eefd1e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0187dfcb-cbe9-47c5-97f9-e88f39539d76", "AQAAAAIAAYagAAAAEKnZ5Z9C9k0z3+fMCxaALyq74GqmvzOc1R8ESQzHbyrz/xJqX/CHtCVqBP56VXnTYw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
