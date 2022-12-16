using MediatR;
using OnlineMovieReservationSystem.Application.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.MovieCommands
{
    public record AddMultipleMoviesCommand(List<MovieDto> Movies) : IRequest<ServiceResponse<List<Movie>>>;
}
