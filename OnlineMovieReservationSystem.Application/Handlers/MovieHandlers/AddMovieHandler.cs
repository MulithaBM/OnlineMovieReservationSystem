using AutoMapper;
using MediatR;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Application.Handlers.MovieHandlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ServiceResponse<List<Movie>>>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public AddMovieHandler(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Movie>>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request.Movie);

            return await _movieService.AddMovie(movie);
        }
    }
}
