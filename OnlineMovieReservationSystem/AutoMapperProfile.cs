using AutoMapper;
using OnlineMovieReservationSystem.Dtos.Movie;
using OnlineMovieReservationSystem.Dtos.Venue;
using OnlineMovieReservationSystem.Models;

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
