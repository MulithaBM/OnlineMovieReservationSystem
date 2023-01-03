using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repositories.VenueRepository
{
    public class VenueQueryRepository : IVenueQueryRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Venue> dbSet;

        public VenueQueryRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Venues;
        }

        public async Task<IEnumerable<Venue>> Get()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Venue> GetById(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
