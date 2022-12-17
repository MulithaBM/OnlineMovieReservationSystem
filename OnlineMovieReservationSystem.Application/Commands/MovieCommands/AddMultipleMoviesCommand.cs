using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.MovieCommands
{
    public record AddMultipleMoviesCommand(List<MovieDto> Movies) : IRequest<ServiceResponse<List<Movie>>>;
}
