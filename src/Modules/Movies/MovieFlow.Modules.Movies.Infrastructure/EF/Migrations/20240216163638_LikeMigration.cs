using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class LikeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativeLikes",
                schema: "movies",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PositiveLikes",
                schema: "movies",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPositive = table.Column<bool>(type: "boolean", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "movies",
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ReviewId",
                schema: "movies",
                table: "Likes",
                column: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes",
                schema: "movies");

            migrationBuilder.AddColumn<long>(
                name: "NegativeLikes",
                schema: "movies",
                table: "Reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PositiveLikes",
                schema: "movies",
                table: "Reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
