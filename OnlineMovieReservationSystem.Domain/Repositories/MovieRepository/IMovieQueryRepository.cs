using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.MovieRepository
{
    public interface IMovieQueryRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> Get();
        Task<Movie> GetById(int id);
    }
}
