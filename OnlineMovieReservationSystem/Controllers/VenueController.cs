using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Venue>>>> GetAllVenues()
        {
            var response = await _venueService.GetAllVenues();

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Venue>>> GetSingleVenue(int id)
        {
            var response = await _venueService.GetVenueById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Venue>>> AddVenue(VenueDto newVenue)
        {
            /*var response = await _venueService.AddVenue(newVenue);

            if (response.Data == null)
            {
                return BadRequest(response);
            }
            
            return Ok(response);*/

            throw new NotImplementedException();
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<ServiceResponse<List<Venue>>>> AddMultipleVenues(List<VenueDto> newVenues)
        {
            /*var response = await _venueService.AddMultipleVenues(newVenues);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);*/

            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Venue>>> DeleteVenue(int id)
        {
            var response = await _venueService.DeleteVenue(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
