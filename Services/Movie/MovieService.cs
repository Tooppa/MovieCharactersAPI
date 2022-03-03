using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            if (movie.FranchiseId != null)
            {
                Franchise franchise = await _context.Franchises.FindAsync(movie.FranchiseId);
                if (franchise == null)
                    throw new KeyNotFoundException();
            }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int movieId)
        {
            Movie movie = await _context.Movies.Include(m => m.Characters).Where(m => m.Id == movieId).FirstAsync();
            return movie.Characters;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Characters).ToListAsync();
        }


        public async Task<Movie> GetSpecificMovieAsync(int id)
        {
            return await _context.Movies.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            if(movie.FranchiseId != null)
            {
                Franchise franchise = await _context.Franchises.FindAsync(movie.FranchiseId);
                if (franchise == null)
                    throw new KeyNotFoundException();
            }
            
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieCharactersAsync(int movieId, List<int> newCharacters)
        {
            Movie movieToUpdateCharacters = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.Id == movieId)
                .FirstAsync();

            List<Character> characters = new();
            foreach (int charId in newCharacters)
            {
                Character character = await _context.Characters.FindAsync(charId);
                if (character == null)
                    throw new KeyNotFoundException();
                characters.Add(character);
            }
            movieToUpdateCharacters.Characters = characters;
            await _context.SaveChangesAsync();

        }
    }
}
