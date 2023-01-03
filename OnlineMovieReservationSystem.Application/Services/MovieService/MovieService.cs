using AutoMapper;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Application.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieQueryRepository _movieQueryRepository;
        private readonly IMovieCommandRepository _movieCommandRepository;
        private readonly IMapper _mapper;
        private readonly IDataContext _c;

        public MovieService(IMovieQueryRepository movieQueryRepository, IMovieCommandRepository movieCommandRepository, IMapper mapper, IDataContext c)
        {
            _movieQueryRepository = movieQueryRepository;
            _movieCommandRepository = movieCommandRepository;
            _mapper = mapper;
            _c = c;
        }

        public async Task<ServiceResponse<List<Movie>>> GetAllMovies()
        {
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                var movies = (List<Movie>) await _movieQueryRepository.Get();

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
                var movie = await _movieQueryRepository.GetById(id);

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
            Console.WriteLine(_c.GetHashCode());
            var response = new ServiceResponse<List<Movie>>();

            Console.WriteLine(newMovie.Title);
 
            try
            {
                var movie = _mapper.Map<Movie>(newMovie);

                await _movieCommandRepository.Add(movie);

                response.Data = (List<Movie>)await _movieQueryRepository.Get();
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

                await _movieCommandRepository.AddRange(movies);

                response.Data = (List<Movie>) await _movieQueryRepository.Get();
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
                var movie = await _movieQueryRepository.GetById(id);

                if (movie == null)
                {
                    response.Success = false;
                    response.Message = "Movie not found";

                    return response;
                }

                await _movieCommandRepository.Remove(movie);

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
