using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Session;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.SessionCommands
{
    public record AddSessionCommand(SessionDto Session) : IRequest<ServiceResponse<List<Session>>>;
}
