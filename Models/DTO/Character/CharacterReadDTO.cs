using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
