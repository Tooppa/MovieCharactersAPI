using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    { 
        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        /// <summary>
        /// Gets a specific movie with id
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns></returns>
        public Task<Movie> GetSpecificMovieAsync(int id);
        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="movie">New movie object</param>
        /// <returns></returns>
        public Task<Movie> AddMovieAsync(Movie movie);
        /// <summary>
        /// Updates the movie
        /// </summary>
        /// <param name="movie">Id of the movie</param>
        /// <exception cref="KeyNotFoundException">When a movie has an invalid franchise id i.e. franchise doesn't exist</exception>
        /// <returns></returns>
        public Task UpdateMovieAsync(Movie movie);
        /// <summary>
        /// Deletes the movie 
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <exception cref="KeyNotFoundException">When a movie has an invalid franchise id i.e. franchise doesn't exist</exception>
        /// <returns></returns>
        public Task DeleteMovieAsync(int id);
        /// <summary>
        /// Updates the characters in a movie
        /// </summary>
        /// <param name="movieId">Id of the movie</param>
        /// <param name="newCharacters">List of character ids</param>
        /// <returns></returns>
        public Task UpdateMovieCharactersAsync(int movieId, List<int> newCharacters);
        /// <summary>
        /// Gets all the characters in the movie
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <exception cref="KeyNotFoundException">When a movie has an invalid franchise id i.e. franchise doesn't exist</exception>
        /// <returns></returns>
        public Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int id);
        /// <summary>
        /// Checks if the movie exists
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns></returns>
        public bool MovieExists(int id);
    }
}
