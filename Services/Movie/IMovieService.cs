using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    { 
        /// <summary>
        /// gets all the movies
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        /// <summary>
        /// gets a specific movie with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Movie> GetSpecificMovieAsync(int id);
        /// <summary>
        /// adds movies to the database
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public Task<Movie> AddMovieAsync(Movie movie);
        /// <summary>
        /// Updates the movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public Task UpdateMovieAsync(Movie movie);
        /// <summary>
        /// Deletes the movie 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteMovieAsync(int id);
        /// <summary>
        /// updates the characters in a movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="newCharacters"></param>
        /// <returns></returns>
        public Task UpdateMovieCharactersAsync(int movieId, List<int> newCharacters);
        /// <summary>
        /// gets all the characters in the movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int id);
        /// <summary>
        /// checks if the movie exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool MovieExists(int id);
    }
}
