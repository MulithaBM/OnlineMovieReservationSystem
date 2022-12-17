using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Session;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> GetSessions()
        {
            var response = await _sessionService.GetAllSessions();

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Session>>> GetSession(int id)
        {
            var response = await _sessionService.GetSessionById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> AddSession(SessionDto newSession)
        {
            /*var response = await _sessionService.AddSession(newSession);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);*/

            throw new NotImplementedException();
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> AddMultipleSessions(List<SessionDto> newSessions)
        {
            /*var response = await _sessionService.AddMultipleSessions(newSessions);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);*/

            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Session>>> DeleteSession(int id)
        {
            var response = await _sessionService.DeleteSession(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
