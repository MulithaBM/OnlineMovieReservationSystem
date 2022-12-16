using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Models;
using OnlineMovieReservationSystem.Queries.MovieQueries;
using OnlineMovieReservationSystem.Services.MovieService;

namespace OnlineMovieReservationSystem.Handlers
{
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;

        public GetMovieListHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            return await _movieService.GetAllMovies();
        }
    }
}
