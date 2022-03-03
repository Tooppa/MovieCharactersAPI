using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IFranchiseService
    {
        /// <summary>
        /// Gets all the franchises
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        /// <summary>
        /// Gets all the movies in the franchise
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns></returns>
        public Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id);
        /// <summary>
        /// Gets all the characters for the franchise
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns></returns>
        public Task<IEnumerable<Character>> GetAllCharactersInFranchiseAsync(int id);
        /// <summary>
        /// Gets a specific franchise with the franchise id
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns></returns>
        public Task<Franchise> GetSpecificFranchiseAsync(int id);
        /// <summary>
        /// Add a new franchise
        /// </summary>
        /// <param name="franchise">New franchise object</param>
        /// <returns></returns>
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        /// <summary>
        /// Updates the franchise 
        /// </summary>
        /// <param name="franchise">Modified franchise object</param>
        /// <returns></returns>
        public Task UpdateFranchiseAsync(Franchise franchise);
        /// <summary>
        /// Deletes the franchise 
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns></returns>
        public Task DeleteFranchiseAsync(int id);
        /// <summary>
        /// Updates the movies in the franchise
        /// </summary>
        /// <param name="franchiseId">Id of the franchise</param>
        /// <param name="newMovies">List of movie ids</param>
        /// <returns></returns>
        public Task UpdateMoviesInFranchiseAsync(int franchiseId, List<int> newMovies);
        /// <summary>
        /// Checks if the franchise exists
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <exception cref="KeyNotFoundException">When a movie id is invalid i.e. movie doesn't exist</exception>
        /// <returns></returns>
        public bool FranchiseExists(int id);
    }
}
