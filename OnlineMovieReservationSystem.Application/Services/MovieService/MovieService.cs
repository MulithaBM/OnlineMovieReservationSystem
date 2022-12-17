using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Application.Data;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MovieService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Movie>>> AddMovie(MovieDto newMovie)
        {
            var response = new ServiceResponse<List<Movie>>();
 
            try
            {
                var movie = _mapper.Map<Movie>(newMovie);
                
                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();

                //await _context.Movies.AddAsync(newMovie);
                //await _context.SaveChangesAsync();

                response.Data = await _context.Movies.ToListAsync();

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
                
                await _context.Movies.AddRangeAsync(movies);
                await _context.SaveChangesAsync();

                //await _context.Movies.AddRangeAsync(newMovies);
                //await _context.SaveChangesAsync();

                response.Data = await _context.Movies.ToListAsync();
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
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if(movie == null)
                {
                    response.Success = false;
                    response.Message = "Movie not found";

                    return response;
                }

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                response.Data = movie;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Movie>>> GetAllMovies()
        {
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                var movies = await _context.Movies.ToListAsync();

                if(!movies.Any())
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
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if(movie == null)
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
    }
}
