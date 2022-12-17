using AutoMapper;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;

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
