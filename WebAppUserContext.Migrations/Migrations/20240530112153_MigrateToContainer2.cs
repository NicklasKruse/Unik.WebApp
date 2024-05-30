using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class MigrateToContainer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dad08d-70d6-4056-b58f-63685eb1cfb4",
                column: "ConcurrencyStamp",
                value: "95d26ae5-386d-4aeb-a82b-9a6c9c2cc688");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51db585d-dfdb-4905-9c37-508424d019c0",
                column: "ConcurrencyStamp",
                value: "aa4322b8-629a-4345-a4c9-6e73e36070b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b",
                column: "ConcurrencyStamp",
                value: "9d5110f2-dd77-400a-801a-eab55aa7e023");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9346c3-fa10-4f98-83ea-33c6b5711ad1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "649c27f5-fd7c-483f-b9e1-c537a2fc700e", "AQAAAAIAAYagAAAAEGjMmiCau68hE4mtEh0yGMA9Rb7Q5pZnLmhlDe/EruIEjHGY5dHV1DcOdb21cDUjog==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
