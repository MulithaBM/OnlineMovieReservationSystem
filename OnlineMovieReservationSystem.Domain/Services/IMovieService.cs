using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetAllMovies();
        Task<ServiceResponse<Movie>> GetMovieById(int id);
        Task<ServiceResponse<List<Movie>>> AddMovie(Movie newMovie);
        Task<ServiceResponse<Movie>> DeleteMovie(int id);
        Task<ServiceResponse<List<Movie>>> AddMultipleMovies(List<Movie> newMovies);
    }
}
