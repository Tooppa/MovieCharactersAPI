using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Alias { get; set; }
        public Gender Gender { get; set; }
        public string? Picture { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
