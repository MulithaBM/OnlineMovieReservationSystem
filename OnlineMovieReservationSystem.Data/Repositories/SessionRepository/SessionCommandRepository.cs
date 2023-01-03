using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.SessionRepository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repositories.SessionRepository
{
    public class SessionCommandRepository : ISessionCommandRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Session> dbSet;

        public SessionCommandRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Sessions;
        }

        public async Task Add(Session session)
        {
            await dbSet.AddAsync(session);
        }

        public async Task AddRange(IEnumerable<Session> sessions)
        {
            await dbSet.AddRangeAsync(sessions);
        }

        public Task Remove(Session session)
        {
            dbSet.Remove(session);
            return Task.CompletedTask;
        }
    }
}
