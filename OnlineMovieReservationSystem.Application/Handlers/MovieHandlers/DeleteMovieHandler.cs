using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, ServiceResponse<Movie>>
    {
        private readonly IMovieService _movieService;

        public DeleteMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<ServiceResponse<Movie>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.DeleteMovie(request.Id);
        }
    }
}
