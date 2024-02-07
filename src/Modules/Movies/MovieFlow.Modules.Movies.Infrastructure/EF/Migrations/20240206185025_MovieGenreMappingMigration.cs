using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class MovieGenreMappingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGenres_Mapping",
                schema: "movies",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres_Mapping", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Mapping_Genres_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "movies",
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Mapping_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalSchema: "movies",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_Mapping_MoviesId",
                schema: "movies",
                table: "MovieGenres_Mapping",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres_Mapping",
                schema: "movies");
        }
    }
}
