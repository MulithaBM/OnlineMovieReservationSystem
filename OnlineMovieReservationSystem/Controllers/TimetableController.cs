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
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TimetableController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Timetable>>>> GetTimetables()
        {
            var response = new ServiceResponse<List<Timetable>>();

            response.Data = await _context.Timetables.ToListAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Timetable>>> GetTimetable(int id)
        {
            var response = new ServiceResponse<Timetable>();

            var timetable = await _context.Timetables.FirstOrDefaultAsync(t => t.Id == id);

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
            var movie = await _context.Movies.FirstAsync(m => m.Id == newEvent.MovieId);
            var venue = await _context.Venues.FirstAsync(v => v.Id == newEvent.VenueId);

            Timetable timetable = new Timetable
            {
                MovieName = movie,
                VenueName = venue,
            };

            await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<Timetable>>();

            response.Data = await _context.Timetables.ToListAsync();

            return Ok(response);
        }
    }
}
