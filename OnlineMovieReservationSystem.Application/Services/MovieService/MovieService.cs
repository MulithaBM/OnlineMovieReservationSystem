using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Persistence.Data;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repository;

namespace OnlineMovieReservationSystem.Application.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            unitOfWork = new(context);
        }

        public async Task<ServiceResponse<List<Movie>>> GetAllMovies()
        {
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                var movies = (List<Movie>) await unitOfWork.MovieRepository.Get();

                if (!movies.Any())
                {
                    response.Success = false;
                    response.Message = "No movies available";

                    return response;
                }

                response.Data = movies;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Movie>> GetMovieById(int id)
        {
            var response = new ServiceResponse<Movie>();

            try
            {
                var movie = await unitOfWork.MovieRepository.GetById(id);

                if (movie == null)
                {
                    response.Success = false;
                    response.Message = "Movie not found";

                    return response;
                }

                response.Data = movie;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Movie>>> AddMovie(MovieDto newMovie)
        {
            var response = new ServiceResponse<List<Movie>>();
 
            try
            {
                var movie = _mapper.Map<Movie>(newMovie);

                response.Data = (List<Movie>?) await unitOfWork.MovieRepository.Add(movie);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Movie>>> AddMultipleMovies(List<MovieDto> newMovies)
        {
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                var movies = newMovies.Select(m => _mapper.Map<Movie>(m)).ToList();

                response.Data = (List<Movie>?)await unitOfWork.MovieRepository.AddRange(movies);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Movie>> DeleteMovie(int id)
        {
            var response = new ServiceResponse<Movie>();

            try
            {
                var movie = await unitOfWork.MovieRepository.GetById(id);

                if (movie == null)
                {
                    response.Success = false;
                    response.Message = "Movie not found";

                    return response;
                }

                response.Data = await unitOfWork.MovieRepository.Remove(movie);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
