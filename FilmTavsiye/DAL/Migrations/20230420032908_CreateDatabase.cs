using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PosterPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Adult = table.Column<bool>(type: "boolean", nullable: false),
                    Overview = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ReleaseDate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    GenreIds = table.Column<List<int>>(type: "integer[]", nullable: false),
                    TmdbId = table.Column<int>(type: "integer", nullable: false),
                    OriginalTitle = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    OriginalLanguage = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    BackdropPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Popularity = table.Column<double>(type: "double precision", nullable: false),
                    VoteCount = table.Column<int>(type: "integer", nullable: false),
                    Video = table.Column<bool>(type: "boolean", nullable: false),
                    VoteAverage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Score = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieNotes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieNotes_MovieId",
                table: "MovieNotes",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieNotes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
