using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IFranchiseService
    {
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        public Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id);
        public Task<Franchise> GetSpecificFranchiseAsync(int id);
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        public Task UpdateFranchiseAsync(Franchise franchise);
        public Task DeleteFranchiseAsync(int id);
        public Task UpdateMoviesInFranchiseAsync(int movieId, List<int> newMovies);
        public bool FranchiseExists(int id);
    }
}
