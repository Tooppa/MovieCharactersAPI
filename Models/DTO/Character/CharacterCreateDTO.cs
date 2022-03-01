using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterCreateDTO
    {
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Alias can't be longer than 100 characters.")]
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
