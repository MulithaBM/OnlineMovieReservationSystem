using AutoMapper;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Movie>>> GetAllMovies()
        {
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                var movies = (List<Movie>)await _unitOfWork.MovieQueryRepository.Get();

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
                var movie = await _unitOfWork.MovieQueryRepository.GetById(id);

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

                await _unitOfWork.MovieCommandRepository.Add(movie);

                response.Data = (List<Movie>)await _unitOfWork.MovieQueryRepository.Get();
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

                await _unitOfWork.MovieCommandRepository.AddRange(movies);

                response.Data = (List<Movie>) await _unitOfWork.MovieQueryRepository.Get();
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
                var movie = await _unitOfWork.MovieQueryRepository.GetById(id);

                if (movie == null)
                {
                    response.Success = false;
                    response.Message = "Movie not found";

                    return response;
                }

                await _unitOfWork.MovieCommandRepository.Remove(movie);

                response.Data = movie;
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
