using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Dtos.Timetable;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly DataContext _context;

        public TimetableController(IMapper mapper, DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Timetable>>>> GetTimetables()
        {
            var response = new ServiceResponse<List<Timetable>>();

            response.Data = await _context.Timetables
                .Include(t => t.MovieName)
                .Include(t => t.VenueName)
                .ToListAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Timetable>>> GetTimetable(int id)
        {
            var response = new ServiceResponse<Timetable>();

            var timetable = await _context.Timetables
                .Include(t => t.MovieName)
                .Include(t => t.VenueName)
                .FirstOrDefaultAsync(t => t.Id == id);

            if(timetable == null)
            {
                response.Success = false;
                response.Message = "Not found";

                return NotFound(response);
            }

            response.Data = timetable;

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Timetable>>>> AddSchedule(TimetableDto newEvent)
        {
            Movie movie = await _context.Movies.FirstAsync(m => m.Id == newEvent.MovieId);
            Venue venue = await _context.Venues.FirstAsync(v => v.Id == newEvent.VenueId);

            Timetable timetable = new()
            {
                MovieName = movie,
                VenueName = venue,
            };

            await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<Timetable>>();

            response.Data = await _context.Timetables.ToListAsync();

            Console.WriteLine("Movies");
            Console.WriteLine(response.Data[0].MovieName.Title);

            return Ok(response);
        }
    }
}
