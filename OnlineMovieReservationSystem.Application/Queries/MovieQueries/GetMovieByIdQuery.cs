using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.MovieQueries
{
    public record GetMovieByIdQuery(int Id) : IRequest<ServiceResponse<Movie>>;
}
