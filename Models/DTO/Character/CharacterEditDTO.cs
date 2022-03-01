using MovieCharactersAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterEditDTO
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Alias can't be longer than 100 characters.")]
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
