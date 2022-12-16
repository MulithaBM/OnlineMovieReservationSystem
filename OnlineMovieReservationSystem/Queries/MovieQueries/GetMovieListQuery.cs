using MediatR;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Queries.MovieQueries
{
    public record GetMovieListQuery() : IRequest<ServiceResponse<List<Movie>>>;

    //public class GetMovieListQuery() : IRequest<List<Movie>>
    //{
    //}
}
