using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.SessionCommands
{
    public record DeleteSessionCommand(int Id) : IRequest<ServiceResponse<Session>>;
}
