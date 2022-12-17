using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Session;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.SessionCommands
{
    public record AddMultipleSessionsCommand(List<SessionDto> Sessions) : IRequest<ServiceResponse<List<Session>>>;
}
