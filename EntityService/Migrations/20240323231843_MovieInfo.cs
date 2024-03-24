using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityService.Migrations
{
    /// <inheritdoc />
    public partial class MovieInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoColName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMDbLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<bool>(type: "bit", nullable: false),
                    Adventure = table.Column<bool>(type: "bit", nullable: false),
                    Comedy = table.Column<bool>(type: "bit", nullable: false),
                    Drama = table.Column<bool>(type: "bit", nullable: false),
                    Romance = table.Column<bool>(type: "bit", nullable: false),
                    Thriller = table.Column<bool>(type: "bit", nullable: false),
                    ScienceFiction = table.Column<bool>(type: "bit", nullable: false),
                    Animation = table.Column<bool>(type: "bit", nullable: false),
                    Fantasy = table.Column<bool>(type: "bit", nullable: false),
                    Horror = table.Column<bool>(type: "bit", nullable: false),
                    Musical = table.Column<bool>(type: "bit", nullable: false),
                    Mystery = table.Column<bool>(type: "bit", nullable: false),
                    Documentary = table.Column<bool>(type: "bit", nullable: false),
                    War = table.Column<bool>(type: "bit", nullable: false),
                    Crime = table.Column<bool>(type: "bit", nullable: false),
                    Western = table.Column<bool>(type: "bit", nullable: false),
                    FilmNoir = table.Column<bool>(type: "bit", nullable: false),
                    Childrens = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserID, x.MovieID });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieID",
                table: "Movies",
                column: "MovieID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
