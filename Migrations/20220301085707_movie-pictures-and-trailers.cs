using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    public partial class moviepicturesandtrailers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg", "https://www.youtube.com/watch?v=EXeTwQWrcwY" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/fi/a/ab/The_dark_knight_rises.jpg", "https://www.youtube.com/watch?v=g8evyE9TuYk" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "https://www.episodi.fi/wp-content/uploads/Split.jpg", "https://www.youtube.com/watch?v=84TouqfIsiI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Picture", "Trailer" },
                values: new object[] { "", "" });
        }
    }
}
