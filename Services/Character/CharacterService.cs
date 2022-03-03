using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieDbContext _context;

        public CharacterService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public bool CharacterExists(int id)
        {
            return _context.Characters.Any(c => c.Id == id);
        }

        public async Task DeleteCharacterAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters.ToListAsync();

        }

        public async Task<Character> GetSpecificCharacterAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
