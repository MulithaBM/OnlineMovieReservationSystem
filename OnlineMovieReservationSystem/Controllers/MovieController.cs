using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Application.Queries.MovieQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMovieReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMediator _mediator;

        public MovieController(IMovieService movieService, IMediator mediator) 
        {
            _movieService = movieService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAllMovies() 
        {
            var response = await _mediator.Send(new GetMovieListQuery());

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetSingleMovie(int id)
        {
            var response = await _mediator.Send(new GetMovieByIdQuery(id));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> AddMovie(MovieDto newMovie)
        {
            var response = await _mediator.Send(new AddMovieCommand(newMovie));

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> AddMultipleMovies(List<MovieDto> newMovies)
        {
            var response = await _mediator.Send(new AddMultipleMoviesCommand(newMovies));

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
