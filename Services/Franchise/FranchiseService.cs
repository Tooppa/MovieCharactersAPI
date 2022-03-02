using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDbContext _context;

        public FranchiseService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id)
        {
            return await _context.Movies.Include(f => f.Characters).Where(m => m.FranchiseId == id).ToListAsync();
        }

        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
        {
            return await _context.Franchises.Include(f => f.Movies).ToListAsync();
        }

        public async Task<Franchise> GetSpecificFranchiseAsync(int id)
        {
            return await _context.Franchises.Include(f => f.Movies).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMoviesInFranchiseAsync(int franchiseId, List<int> newMovies)
        {
            Franchise franchiseToUpdateMovies = await _context.Franchises
                .Include(m => m.Movies)
                .Where(m => m.Id == franchiseId)
                .FirstAsync();

            List<Movie> movies = new();
            foreach (int movieId in newMovies)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                if (movie == null)
                    throw new KeyNotFoundException();
                movies.Add(movie);
            }
            franchiseToUpdateMovies.Movies = movies;
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Character>> GetAllCharactersInFranchiseAsync(int id)
        {
            List<Movie> movies = await _context.Movies.Include(f => f.Characters).Where(m => m.FranchiseId == id).ToListAsync();
            List<Character> characters = new List<Character>();
            foreach (Movie movie in movies)
            {
                characters.AddRange(movie.Characters);
            }
            return characters.Distinct();
        }
    }
}
