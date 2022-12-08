using Microsoft.AspNetCore.Mvc;
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
        private readonly DataContext _context;

        public MovieController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies() 
        {
            return Ok(_context.Movies.ToList());
        }

        [HttpPost]
        public IActionResult AddMovie(MovieDto movie)
        {

        }
    }
}
