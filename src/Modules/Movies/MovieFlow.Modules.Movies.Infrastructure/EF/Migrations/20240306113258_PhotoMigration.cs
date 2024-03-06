using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class PhotoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Alt = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviePhotos",
                schema: "movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviePhotos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "movies",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "movies",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePhotos_MovieId",
                schema: "movies",
                table: "MoviePhotos",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePhotos_PhotoId",
                schema: "movies",
                table: "MoviePhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_FileName",
                schema: "movies",
                table: "Photos",
                column: "FileName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePhotos",
                schema: "movies");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "movies");
        }
    }
}
