using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharactersAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public MovieDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets the string required for the connection to the database
        /// </summary>
        /// <returns>
        /// String from SqlConnectionStringBuilder with right information
        /// </returns>
        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            // search local machine for SQL Express Server instance
            sqlConnectionStringBuilder.DataSource = ".\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "MovieCharacters";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            // otherwise connection fails due to untrusted SSL certificate chain
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise
                {
                    Id = 1,
                    Name = "DC Comics",
                    Description = "Traditional Superheroes"
                },
                new Franchise
                {
                    Id = 2,
                    Name = "Unbreakable",
                    Description = "Realistic Superheroes"
                }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Dark Knight",
                    Genre = "Action",
                    ReleaseYear = 2008,
                    Director = "Christopher Nolan",
                    Picture = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight Rises",
                    Genre = "Action",
                    ReleaseYear = 2012,
                    Director = "Christopher Nolan",
                    Picture = "https://upload.wikimedia.org/wikipedia/fi/a/ab/The_dark_knight_rises.jpg",
                    Trailer = "https://www.youtube.com/watch?v=g8evyE9TuYk",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "Split",
                    Genre = "Thriller",
                    ReleaseYear = 2016,
                    Director = "M. Night Shyamalan",
                    Picture = "https://www.episodi.fi/wp-content/uploads/Split.jpg",
                    Trailer = "https://www.youtube.com/watch?v=84TouqfIsiI",
                    FranchiseId = 2
                }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Bruce Wayne",
                    Alias = "Batman",
                    Gender = Gender.Male,
                    Picture = "https://m.media-amazon.com/images/M/MV5BMTQyODI2MDczOF5BMl5BanBnXkFtZTcwNDczMTk2Mw@@._V1_FMjpg_UY720_.jpg"
                },
                new Character
                {
                    Id = 2,
                    Name = "Unknown",
                    Alias = "Joker",
                    Gender = Gender.Male,
                    Picture = "https://m.media-amazon.com/images/M/MV5BMjA5ODU3NTI0Ml5BMl5BanBnXkFtZTcwODczMTk2Mw@@._V1_FMjpg_UX1280_.jpg"
                },
                new Character
                {
                    Id = 3,
                    Name = "Unknown",
                    Alias = "Bane",
                    Gender = Gender.Male,
                    Picture = "https://m.media-amazon.com/images/M/MV5BMjE3MzMxMDAxNV5BMl5BanBnXkFtZTcwOTUyMzgwOA@@._V1_FMjpg_UY721_.jpg"
                },
                new Character
                {
                    Id = 4,
                    Name = "Casey Cooke",
                    Alias = "",
                    Gender = Gender.Female,
                    Picture = "https://m.media-amazon.com/images/M/MV5BMGMyYmQ2ZGYtMjFhMS00M2ZkLWE2NWYtMTRlZGExNzIzOTNiXkEyXkFqcGdeQXVyNjQ4ODE4MzQ@._V1_FMjpg_UX1280_.jpg"
                }
            );
            modelBuilder
                .Entity<Character>()
                .HasMany(p => p.Movies)
                .WithMany(p => p.Characters)
                .UsingEntity(j => j.HasData(
                    new { CharactersId = 1, MoviesId = 1 },
                    new { CharactersId = 1, MoviesId = 2 },
                    new { CharactersId = 2, MoviesId = 1 },
                    new { CharactersId = 3, MoviesId = 2 },
                    new { CharactersId = 4, MoviesId = 3 }
            ));
        }
    }
}
