using AutoMapper;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Application.Dtos.Movie;
using OnlineMovieReservationSystem.Application.Dtos.Venue;
using OnlineMovieReservationSystem.Application.Commands.MovieCommands;

namespace OnlineMovieReservationSystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<VenueDto, Venue>();
        }
    }
}
