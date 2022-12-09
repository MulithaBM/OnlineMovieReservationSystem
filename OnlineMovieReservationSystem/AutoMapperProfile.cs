using AutoMapper;
using OnlineMovieReservationSystem.Dtos.Movie;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
        }
    }
}
