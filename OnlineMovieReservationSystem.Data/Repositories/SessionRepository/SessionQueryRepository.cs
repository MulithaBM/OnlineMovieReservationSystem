using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.SessionRepository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repositories.SessionRepository
{
    public class SessionQueryRepository : ISessionQueryRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Session> dbSet;
        public SessionQueryRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Sessions;
        }
        public async Task<IEnumerable<Session>> Get()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Session> GetById(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
