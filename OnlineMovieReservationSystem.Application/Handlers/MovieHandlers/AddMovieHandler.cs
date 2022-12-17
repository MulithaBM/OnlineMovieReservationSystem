using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;

        public AddMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.AddMovie(request.Movie);
        }
    }
}
