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
        private readonly IMapper _mapper;

        public AddMultipleMoviesHandler(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMultipleMoviesCommand request, CancellationToken cancellationToken)
        {
            var movies = request.Movies.Select(m => _mapper.Map<Movie>(m)).ToList();

            return await _movieService.AddMultipleMovies(movies);
        }
    }
}
