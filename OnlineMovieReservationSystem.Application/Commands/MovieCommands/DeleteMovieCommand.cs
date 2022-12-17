using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.MovieCommands
{
    public record DeleteMovieCommand(int Id) : IRequest<ServiceResponse<Movie>>;
}
