using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repositories.MovieRepository
{
    public class MovieQueryRepository : IMovieQueryRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Movie> dbSet;

        public MovieQueryRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Movies;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
