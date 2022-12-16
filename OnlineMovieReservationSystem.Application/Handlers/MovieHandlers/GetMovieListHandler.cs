using MediatR;
using OnlineMovieReservationSystem.Application.Queries.MovieQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
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
