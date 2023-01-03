using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repositories.MovieRepository
{
    public class MovieCommandRepository : IMovieCommandRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Movie> dbSet;

        public MovieCommandRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Movies;
        }

        public async Task Add(Movie movie)
        {
            await dbSet.AddAsync(movie);
        }

        public async Task AddRange(IEnumerable<Movie> movies)
        {
            await dbSet.AddRangeAsync(movies);
        }

        public Task Remove(Movie movie)
        {
            dbSet.Remove(movie);
            return Task.CompletedTask;
        }
    }
}
