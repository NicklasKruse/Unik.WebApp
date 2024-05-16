using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MemberWithAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "MemberWithAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "MemberWithAddress",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "member",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                schema: "member",
                table: "Member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "member",
                table: "Member",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "invitation",
                table: "Invitation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                schema: "invitation",
                table: "Invitation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "invitation",
                table: "Invitation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "booking",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                schema: "booking",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "booking",
                table: "Booking",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MemberWithAddress");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "MemberWithAddress");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "MemberWithAddress");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                schema: "member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "invitation",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                schema: "invitation",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "invitation",
                table: "Invitation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                schema: "booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "booking",
                table: "Booking");
        }
    }
}
