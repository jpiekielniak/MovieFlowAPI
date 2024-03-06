using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class DirectorPhotosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectorPhotos",
                schema: "movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectorPhotos_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalSchema: "movies",
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "movies",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorPhotos_DirectorId",
                schema: "movies",
                table: "DirectorPhotos",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorPhotos_PhotoId",
                schema: "movies",
                table: "DirectorPhotos",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorPhotos",
                schema: "movies");
        }
    }
}
