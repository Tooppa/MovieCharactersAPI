using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    { 
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetSpecificMovieAsync(int id);
        public Task<Movie> AddMovieAsync(Movie character);
        public Task UpdateMovieAsync(Movie character);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
    }
}
