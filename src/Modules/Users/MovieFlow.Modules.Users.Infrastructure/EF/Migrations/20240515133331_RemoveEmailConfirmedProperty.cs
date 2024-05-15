using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Users.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailConfirmedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmedAt",
                schema: "users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Permissions",
                schema: "users",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "users",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmailConfirmedAt",
                schema: "users",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Permissions",
                schema: "users",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
