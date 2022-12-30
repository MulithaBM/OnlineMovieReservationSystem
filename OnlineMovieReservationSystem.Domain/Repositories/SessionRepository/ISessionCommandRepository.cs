using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.SessionRepository
{
    public interface ISessionCommandRepository : IRepository<Session>
    {
        Task Add(Session session);
        Task AddRange(IEnumerable<Session> sessions);
        Task Remove(Session session);
    }
}
