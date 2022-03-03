using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface ICharacterService
    {
        /// <summary>
        /// Gets all the characters
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Character>> GetAllCharactersAsync();
        /// <summary>
        /// Gets a specific character with id
        /// </summary>
        /// <param name="id">Id of the character</param>
        /// <returns></returns>
        public Task<Character> GetSpecificCharacterAsync(int id);
        /// <summary>
        /// Adds a character to the database
        /// </summary>
        /// <param name="character">New character object</param>
        /// <returns></returns>
        public Task<Character> AddCharacterAsync(Character character);
        /// <summary>
        /// Updates the character
        /// </summary>
        /// <param name="character">Modified character object</param>
        /// <returns></returns>
        public Task UpdateCharacterAsync(Character character);
        /// <summary>
        /// Deletes the character
        /// </summary>
        /// <param name="id">Id of the character</param>
        /// <returns></returns>
        public Task DeleteCharacterAsync(int id);
        /// <summary>
        /// Checks if the character exists
        /// </summary>
        /// <param name="id">Id of the character</param>
        /// <returns></returns>
        public bool CharacterExists(int id);
    }
}
