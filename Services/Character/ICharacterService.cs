using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAllCharactersAsync();
        public Task<Character> GetSpecificCharacterAsync(int id);
        public Task<Character> AddCharacterAsync(Character character);
        public Task UpdateCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public bool CharacterExists(int id);
    }
}
