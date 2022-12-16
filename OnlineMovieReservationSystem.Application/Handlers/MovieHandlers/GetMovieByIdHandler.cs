using MediatR;
using OnlineMovieReservationSystem.Application.Queries.MovieQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, ServiceResponse<Movie>>
    {
        private readonly IMovieService _movieService;
        public GetMovieByIdHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<ServiceResponse<Movie>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _movieService.GetMovieById(request.Id);
        }
    }
}
