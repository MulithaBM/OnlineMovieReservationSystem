using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.VenueCommands
{
    public record AddMultipleVenuesCommand(List<VenueDto> Venues) : IRequest<ServiceResponse<List<Venue>>>;
}
