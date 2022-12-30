using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;

public interface IMovieCommandRepository : IRepository<Movie>
{
    Task Add(Movie movie);
    Task AddRange(IEnumerable<Movie> movies);
    Task Remove(Movie movie);
}
