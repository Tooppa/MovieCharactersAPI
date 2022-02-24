using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
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
    }
}
