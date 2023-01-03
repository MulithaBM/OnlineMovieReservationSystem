using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;
        private readonly IUnitOfWork _unitOfWork;

        public AddMovieHandler(IMovieService movieService, IUnitOfWork unitOfWork)
        {
            _movieService = movieService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movies = await _movieService.AddMovie(request.Movie);
            Console.WriteLine(_unitOfWork.GetHashCode());
            await _unitOfWork.SaveChangesAsync();
            return movies;
        }
    }
}
