using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

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
                    Picture = "",
                    Trailer = "",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight Rises",
                    Genre = "Action",
                    ReleaseYear = 2012,
                    Director = "Christopher Nolan",
                    Picture = "",
                    Trailer = "",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "Split",
                    Genre = "Thriller",
                    ReleaseYear = 2016,
                    Director = "M. Night Shyamalan",
                    Picture = "",
                    Trailer = "",
                    FranchiseId = 2
                }
            );
        }
    }
}
