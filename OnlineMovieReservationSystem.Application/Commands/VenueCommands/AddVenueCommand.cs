using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.VenueCommands
{
    public record AddVenueCommand(VenueDto Venue) : IRequest<ServiceResponse<List<Venue>>>;
}
