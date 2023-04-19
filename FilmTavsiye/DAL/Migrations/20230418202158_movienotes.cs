using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class movienotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "video",
                table: "Movies",
                newName: "Video");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "popularity",
                table: "Movies",
                newName: "Popularity");

            migrationBuilder.RenameColumn(
                name: "overview",
                table: "Movies",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "adult",
                table: "Movies",
                newName: "Adult");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "vote_count",
                table: "Movies",
                newName: "VoteCount");

            migrationBuilder.RenameColumn(
                name: "vote_average",
                table: "Movies",
                newName: "VoteAverage");

            migrationBuilder.RenameColumn(
                name: "tmdb_id",
                table: "Movies",
                newName: "TmdbId");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "Movies",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "poster_path",
                table: "Movies",
                newName: "PosterPath");

            migrationBuilder.RenameColumn(
                name: "original_title",
                table: "Movies",
                newName: "OriginalTitle");

            migrationBuilder.RenameColumn(
                name: "original_language",
                table: "Movies",
                newName: "OriginalLanguage");

            migrationBuilder.RenameColumn(
                name: "genre_ids",
                table: "Movies",
                newName: "GenreIds");

            migrationBuilder.RenameColumn(
                name: "backdrop_path",
                table: "Movies",
                newName: "BackdropPath");

            migrationBuilder.CreateTable(
                name: "MovieNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "Movies",
                newName: "video");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "Movies",
                newName: "popularity");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "Movies",
                newName: "overview");

            migrationBuilder.RenameColumn(
                name: "Adult",
                table: "Movies",
                newName: "adult");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VoteCount",
                table: "Movies",
                newName: "vote_count");

            migrationBuilder.RenameColumn(
                name: "VoteAverage",
                table: "Movies",
                newName: "vote_average");

            migrationBuilder.RenameColumn(
                name: "TmdbId",
                table: "Movies",
                newName: "tmdb_id");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Movies",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "Movies",
                newName: "poster_path");

            migrationBuilder.RenameColumn(
                name: "OriginalTitle",
                table: "Movies",
                newName: "original_title");

            migrationBuilder.RenameColumn(
                name: "OriginalLanguage",
                table: "Movies",
                newName: "original_language");

            migrationBuilder.RenameColumn(
                name: "GenreIds",
                table: "Movies",
                newName: "genre_ids");

            migrationBuilder.RenameColumn(
                name: "BackdropPath",
                table: "Movies",
                newName: "backdrop_path");
        }
    }
}
