using OnlineMovieReservationSystem.Dtos.Venue;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Services.VenueService
{
    public interface IVenueService
    {
        Task<ServiceResponse<List<Venue>>> GetAllVenues();
        Task<ServiceResponse<Venue>> GetVenueById(int id);
        Task<ServiceResponse<List<Venue>>> AddVenue(VenueDto newVenue);
        Task<ServiceResponse<Venue>> DeleteVenue(int id);
        Task<ServiceResponse<List<Venue>>> AddMultipleVenues(List<VenueDto> newVenues);
    }
}
