using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IFranchiseService
    {
        /// <summary>
        /// gets all the franchises
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        /// <summary>
        /// gets all the movies in the franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id);
        /// <summary>
        /// gets all the characters for the franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<Character>> GetAllCharactersInFranchiseAsync(int id);
        /// <summary>
        /// gets a specific franchise with the franchise id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Franchise> GetSpecificFranchiseAsync(int id);
        /// <summary>
        /// add a new franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        /// <summary>
        /// Updates the franchise 
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public Task UpdateFranchiseAsync(Franchise franchise);
        /// <summary>
        /// Deletes the franchise 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteFranchiseAsync(int id);
        /// <summary>
        /// updates the movies in the franchise
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="newMovies"></param>
        /// <returns></returns>
        public Task UpdateMoviesInFranchiseAsync(int movieId, List<int> newMovies);
        /// <summary>
        /// checks if the franchise exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FranchiseExists(int id);
    }
}
