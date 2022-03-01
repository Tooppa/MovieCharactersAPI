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
        public Task UpdateMovieCharactersAsync(int movieId, List<int> newCharacters);
        public Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int id);
        public bool MovieExists(int id);
    }
}
