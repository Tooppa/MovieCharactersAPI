
namespace MovieCharactersAPI.Models.DTO.Movie
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        public string? Picture { get; set; }
        public string? Trailer { get; set; }
        public ICollection<int>? Characters { get; set;}
        public int? FranchiseId { get; set; }
    }
}
