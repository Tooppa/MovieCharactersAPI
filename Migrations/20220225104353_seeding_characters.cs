using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    public partial class seeding_characters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "Gender", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "Batman", 0, "Bruce Wayne", "https://m.media-amazon.com/images/M/MV5BMTQyODI2MDczOF5BMl5BanBnXkFtZTcwNDczMTk2Mw@@._V1_FMjpg_UY720_.jpg" },
                    { 2, "Joker", 0, "Unknown", "https://m.media-amazon.com/images/M/MV5BMjA5ODU3NTI0Ml5BMl5BanBnXkFtZTcwODczMTk2Mw@@._V1_FMjpg_UX1280_.jpg" },
                    { 3, "Bane", 0, "Unknown", "https://m.media-amazon.com/images/M/MV5BMjE3MzMxMDAxNV5BMl5BanBnXkFtZTcwOTUyMzgwOA@@._V1_FMjpg_UY721_.jpg" },
                    { 4, "", 1, "Casey Cooke", "https://m.media-amazon.com/images/M/MV5BMGMyYmQ2ZGYtMjFhMS00M2ZkLWE2NWYtMTRlZGExNzIzOTNiXkEyXkFqcGdeQXVyNjQ4ODE4MzQ@._V1_FMjpg_UX1280_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersId", "MoviesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersId", "MoviesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersId", "MoviesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersId", "MoviesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharactersId", "MoviesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
