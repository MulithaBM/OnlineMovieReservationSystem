using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetAllMovies();
        Task<ServiceResponse<Movie>> GetMovieById(int id);
        Task<ServiceResponse<List<Movie>>> AddMovie(MovieDto newMovie);
        Task<ServiceResponse<List<Movie>>> AddMultipleMovies(List<MovieDto> newMovies);
        Task<ServiceResponse<Movie>> DeleteMovie(int id);
    }
}
