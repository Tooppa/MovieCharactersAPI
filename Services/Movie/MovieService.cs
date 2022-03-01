using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public class MovieService : IMovieService
    {
        public Task<Movie> AddMovieAsync(Movie character)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetSpecificMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool MovieExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieAsync(Movie character)
        {
            throw new NotImplementedException();
        }
    }
}
