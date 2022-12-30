using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, ServiceResponse<Movie>>
    {
        private readonly IMovieService _movieService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMovieHandler(IMovieService movieService, IUnitOfWork unitOfWork)
        {
            _movieService = movieService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Movie>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.DeleteMovie(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return movie;
        }
    }
}
