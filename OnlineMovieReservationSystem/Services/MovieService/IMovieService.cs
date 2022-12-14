using OnlineMovieReservationSystem.Dtos.Movie;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Services.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetAllMovies();
        Task<ServiceResponse<Movie>> GetMovieById(int id);
        Task<ServiceResponse<List<Movie>>> AddMovie(MovieDto newMovie);
        Task<ServiceResponse<Movie>> DeleteMovie(int id);
        Task<ServiceResponse<List<Movie>>> AddMultipleMovies(List<MovieDto> newMovies);
    }
}
