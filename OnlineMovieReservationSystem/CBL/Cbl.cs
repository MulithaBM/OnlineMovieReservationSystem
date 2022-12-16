using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.CBL
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cbl : ControllerBase
    {
        private readonly DataContext _context;
        public Cbl(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> GetMovieSessions(int id)
        {
            var response = new ServiceResponse<List<Session>>();

            try
            {
                var sessions = await _context.Sessions
                    .Include(s => s.Movie)
                    .Include(s => s.Venue)
                    .Where(s => s.Movie.Id == id).ToListAsync();

                if(!sessions.Any())
                {
                    response.Success = false;
                    response.Message = "No sessions found";

                    return response;
                }

                response.Data = sessions;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
