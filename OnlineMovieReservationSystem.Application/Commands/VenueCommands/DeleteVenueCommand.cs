using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.VenueCommands
{
    public record DeleteVenueCommand(int Id) : IRequest<ServiceResponse<Venue>>;
}
