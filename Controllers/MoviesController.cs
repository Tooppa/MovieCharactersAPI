#nullable disable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Movie;
using MovieCharactersAPI.Services;
using System.Net.Mime;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;


        public MoviesController(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        #region CRUD
        /// <summary>
        /// Gets all the movies in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetAllMoviesAsync());
        }

        /// <summary>
        /// Gets a specific movie by their id.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            Movie movie = await _movieService.GetSpecificMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Updates a specific movie.
        /// </summary>
        /// <param name="id">Id of the movie to be updated</param>
        /// <param name="movie">Modified movie object that will replace the the original</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
            {
                return BadRequest();
            }

            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            await _movieService.UpdateMovieAsync(domainMovie);

            return NoContent();
        }
        /// <summary>
        /// Add a new movie to the database.
        /// </summary>
        /// <param name="movie">Movie object to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            domainMovie = await _movieService.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id">Id of the movie to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }
        #endregion
    }
}
