#nullable disable

using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Franchise;
using MovieCharactersAPI.Models.DTO.Movie;
using MovieCharactersAPI.Services;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IMapper mapper, IFranchiseService franchiseService)
        {
            _mapper = mapper;
            _franchiseService = franchiseService;
        }

        #region CRUD
        /// <summary>
        /// Gets all the franchises in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _franchiseService.GetAllFranchisesAsync());
        }

        /// <summary>
        /// Gets a specific franchise by its id.
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            Franchise franchise = await _franchiseService.GetSpecificFranchiseAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseReadDTO>(franchise);
        }

        /// <summary>
        /// Gets all the movies in the database with given franchise id.
        /// </summary>
        /// <param name="id">id of the franchise</param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMoviesByFranchiseId(int id)
        {
            return _mapper.Map<List<MovieReadDTO>>(await _franchiseService.GetAllMoviesInFranchiseAsync(id));
        }

        /// <summary>
        /// Updates a specific franchise.
        /// </summary>
        /// <param name="id">Id of the franchise to be updated</param>
        /// <param name="franchise">Modified franchise object that will replace the the original</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO dtoFranchise)
        {
            if (id != dtoFranchise.Id)
            {
                return BadRequest();
            }

            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }

            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            await _franchiseService.UpdateFranchiseAsync(domainFranchise);

            return NoContent();
        }

        /// <summary>
        /// Add a new franchise to the database.
        /// </summary>
        /// <param name="franchise">Franchise object to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO dtoFranchise)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            domainFranchise = await _franchiseService.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise",
                new { id = domainFranchise.Id },
                _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        /// <summary>
        /// Deletes a franchise from the database.
        /// </summary>
        /// <param name="id">Id of the franchise to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }

            await _franchiseService.DeleteFranchiseAsync(id);

            return NoContent();
        }
        #endregion
    }
}
