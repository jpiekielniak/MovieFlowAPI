using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Users.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class NamePropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "users",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                schema: "users",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "users",
                table: "Users");
        }
    }
}
