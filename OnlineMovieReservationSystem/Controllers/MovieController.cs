using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Dtos.Movie;
using OnlineMovieReservationSystem.Models;
using OnlineMovieReservationSystem.Services.MovieService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMovieReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAllMovies() 
        {
            var response = await _movieService.GetAllMovies();

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetSingleMovie(int id)
        {
            var response = await _movieService.GetMovieById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> AddMovie(MovieDto newMovie)
        {
            var response = await _movieService.AddMovie(newMovie);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> AddMultipleMovies(List<MovieDto> newMovies)
        {
            var response = await _movieService.AddMultipleMovies(newMovies);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> DeleteMovie(int id)
        {
            var response = await _movieService.DeleteMovie(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
