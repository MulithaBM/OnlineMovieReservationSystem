using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Session;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.SessionCommands
{
    public record UpdateSessionCommand(UpdateSessionDto sessionChanges) : IRequest<ServiceResponse<Session>>;
}
