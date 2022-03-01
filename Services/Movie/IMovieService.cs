using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    { 
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetSpecificMovieAsync(int id);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
    }
}
