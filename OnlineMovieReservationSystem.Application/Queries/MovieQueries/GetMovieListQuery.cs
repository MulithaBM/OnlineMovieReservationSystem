//using MediatR;
using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.MovieQueries
{
    public record GetMovieListQuery : IRequest<ServiceResponse<List<Movie>>>;

    //public class GetMovieListQuery() : IRequest<List<Movie>>
    //{
    //}
}
