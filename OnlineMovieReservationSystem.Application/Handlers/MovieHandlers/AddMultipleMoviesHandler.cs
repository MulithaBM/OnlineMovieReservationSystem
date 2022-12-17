using AutoMapper;
using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class AddMultipleMoviesHandler : IRequestHandler<AddMultipleMoviesCommand, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;

        public AddMultipleMoviesHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMultipleMoviesCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.AddMultipleMovies(request.Movies);
        }
    }
}
