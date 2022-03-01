#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;
using MovieCharactersAPI.Services;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/characters")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(IMapper mapper, ICharacterService characterService)
        {
            _mapper = mapper;
            _characterService = characterService;
        }

        #region CRUD
        /// <summary>
        /// Gets all the characters in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _characterService.GetAllCharactersAsync());
        }

        /// <summary>
        /// Gets a specific character by their id.
        /// </summary>
        /// <param name="id">Id of the character</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            Character character = await _characterService.GetSpecificCharacterAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<CharacterReadDTO>(character);
        }

        /// <summary>
        /// Updates a specific character.
        /// </summary>
        /// <param name="id">Id of the character to be updated</param>
        /// <param name="character">Modified character object that will replace the the original</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO dtoCharacter)
        {
            if (id != dtoCharacter.Id)
            {
                return BadRequest();
            }

            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
            await _characterService.UpdateCharacterAsync(domainCharacter);

            return NoContent();
        }

        /// <summary>
        /// Add a new character to the database.
        /// </summary>
        /// <param name="character">Character object to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
            domainCharacter = await _characterService.AddCharacterAsync(domainCharacter);

            return CreatedAtAction("GetCharacter",
                new { id = domainCharacter.Id },
                _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        /// <summary>
        /// Deletes a character from the database.
        /// </summary>
        /// <param name="id">Id of the character to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            await _characterService.DeleteCharacterAsync(id);

            return NoContent();
        }
        #endregion
    }
}