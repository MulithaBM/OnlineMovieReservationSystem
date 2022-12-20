using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;
using MediatR;
using OnlineMovieReservationSystem.Application.Queries.VenueQueries;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Venue>>>> GetAllVenues()
        {
            var response = await _mediator.Send(new GetVenueListQuery());

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Venue>>> GetSingleVenue(int id)
        {
            var response = await _mediator.Send(new GetVenueByIdQuery(id));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Venue>>> AddVenue(VenueDto newVenue)
        {
            var response = await _mediator.Send(new AddVenueCommand(newVenue));

            if (response.Data == null)
            {
                return BadRequest(response);
            }
            
            return Ok(response);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Venue>>>> AddMultipleVenues(List<VenueDto> newVenues)
        {
            var response = await _mediator.Send(new AddMultipleVenuesCommand(newVenues));

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Venue>>> DeleteVenue(int id)
        {
            var response = await _mediator.Send(new DeleteVenueCommand(id));

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
