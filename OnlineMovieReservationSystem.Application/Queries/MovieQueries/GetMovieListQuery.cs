using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.MovieQueries
{
    public record GetMovieListQuery : IRequest<ServiceResponse<List<Movie>>>;
}
