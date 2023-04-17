using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class generateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    poster_path = table.Column<string>(type: "text", nullable: false),
                    adult = table.Column<bool>(type: "boolean", nullable: false),
                    overview = table.Column<string>(type: "text", nullable: false),
                    release_date = table.Column<string>(type: "text", nullable: false),
                    genre_ids = table.Column<List<int>>(type: "integer[]", nullable: false),
                    original_title = table.Column<string>(type: "text", nullable: false),
                    original_language = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    backdrop_path = table.Column<string>(type: "text", nullable: false),
                    popularity = table.Column<double>(type: "double precision", nullable: false),
                    vote_count = table.Column<int>(type: "integer", nullable: false),
                    video = table.Column<bool>(type: "boolean", nullable: false),
                    vote_average = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
