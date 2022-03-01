using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Franchise
{
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Description can't be longer than 100 characters.")]
        public string Description { get; set; }
    }
}
