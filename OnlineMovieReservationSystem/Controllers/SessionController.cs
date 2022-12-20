using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Dtos.Session;
using MediatR;
using OnlineMovieReservationSystem.Application.Queries.SessionQueries;
using OnlineMovieReservationSystem.Application.Commands.SessionCommands;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> GetAllSessions()
        {
            var response = await _mediator.Send(new GetSessionListQuery());

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Session>>> GetSingleSession(int id)
        {
            var response = await _mediator.Send(new GetSessionByIdQuery(id));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> AddSession(SessionDto newSession)
        {
            var response = await _mediator.Send(new AddSessionCommand(newSession));

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Session>>>> AddMultipleSessions(List<SessionDto> newSessions)
        {
            var response = await _mediator.Send(new AddMultipleSessionsCommand(newSessions));

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Session>>> UpdateSession(UpdateSessionDto sessionChanges)
        {
            var response = await _mediator.Send(new UpdateSessionCommand(sessionChanges));

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Session>>> DeleteSession(int id)
        {
            var response = await _mediator.Send(new DeleteSessionCommand(id));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
