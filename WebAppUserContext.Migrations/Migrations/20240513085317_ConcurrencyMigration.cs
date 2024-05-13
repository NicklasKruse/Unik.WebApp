using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ConcurrencyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9a14aa-7257-42dc-8ade-a6f532e4a56c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "459a0043-0770-4ca8-8f36-b5ffdbf91b5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6d05e88-63eb-49a0-9442-528b120cdb0b");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2aa7b3bf-3ed1-47b8-b27b-c56317436f29", null, "Formand", "FORMAND" },
                    { "7b9f5451-f4df-4186-92fe-de5bafba0159", null, "Medlem", "MEDLEM" },
                    { "e6ecc13f-c334-48b9-9eb2-cf429d257735", null, "Bestyrelse", "BESTYRELSE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aa7b3bf-3ed1-47b8-b27b-c56317436f29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b9f5451-f4df-4186-92fe-de5bafba0159");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ecc13f-c334-48b9-9eb2-cf429d257735");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c9a14aa-7257-42dc-8ade-a6f532e4a56c", null, "Formand", "FORMAND" },
                    { "459a0043-0770-4ca8-8f36-b5ffdbf91b5f", null, "Bestyrelse", "BESTYRELSE" },
                    { "a6d05e88-63eb-49a0-9442-528b120cdb0b", null, "Medlem", "MEDLEM" }
                });
        }
    }
}
