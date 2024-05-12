using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppUserContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Webappuserdbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
