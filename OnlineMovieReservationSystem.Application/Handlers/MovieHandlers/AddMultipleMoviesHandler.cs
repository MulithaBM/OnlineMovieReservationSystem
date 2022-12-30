using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class AddMultipleMoviesHandler : IRequestHandler<AddMultipleMoviesCommand, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;
        private readonly IUnitOfWork _unitOfWork;

        public AddMultipleMoviesHandler(IMovieService movieService, IUnitOfWork unitOfWork)
        {
            _movieService = movieService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMultipleMoviesCommand request, CancellationToken cancellationToken)
        {
            var movies = await _movieService.AddMultipleMovies(request.Movies);
            await _unitOfWork.SaveChangesAsync();
            return movies;
        }
    }
}
