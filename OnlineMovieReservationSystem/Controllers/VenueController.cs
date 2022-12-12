using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Dtos.Venue;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Controllers
{
    public class VenueController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VenueController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Venue>>>> GetVenues()
        {
            var response = new ServiceResponse<List<Venue>>();

            response.Data = await _context.Venues.ToListAsync();

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Venue>>> GetVenue(int id)
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);

            var response = new ServiceResponse<Venue>();
            if (venue == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Venue not found";

                return NotFound(response);
            }

            response.Data = venue;

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Venue>>> AddVenue(VenueDto newVenue)
        {
            Venue venue = _mapper.Map<Venue>(newVenue);

            await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<Venue>>();

            response.Data = await _context.Venues.ToListAsync();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Venue>>> DeleteVenue(int id)
        {
            var response = new ServiceResponse<Venue>();

            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);

            if(venue == null)
            {
                response.Success = false;
                response.Message = "Venue not found";

                return NotFound(response);
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            response.Data = venue;

            return Ok(response);
        }
    }
}
