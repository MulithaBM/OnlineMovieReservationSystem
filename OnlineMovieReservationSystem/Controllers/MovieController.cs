using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Dtos.Movie;
using OnlineMovieReservationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMovieReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public MovieController(IMapper mapper, DataContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAllMovies() 
        {
            var response = new ServiceResponse<List<Movie>>();
            response.Data = await _context.Movies.ToListAsync();

            Console.WriteLine("Get Movies");

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetSingleMovie(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            var response = new ServiceResponse<Movie>();
            if(movie == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Movie not found";

                return NotFound(response);
            }
            
            response.Data = movie;

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MovieDto>>>> AddMovie(MovieDto newMovie)
        {
            Movie movie = _mapper.Map<Movie>(newMovie);

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<MovieDto>>();
            response.Data = await _context.Movies.Select(m => _mapper.Map<MovieDto>(m)).ToListAsync();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Movie>>> DeleteMovie(int id)
        {
            var response = new ServiceResponse<Movie>();

            var movie = await _context.Movies.FirstAsync(m => m.Id == id);

            if(movie == null)
            {
                response.Success = false;
                response.Message = "Movie not found";

                return NotFound(response);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            response.Data = movie;

            return Ok(response);
        }
    }
}
