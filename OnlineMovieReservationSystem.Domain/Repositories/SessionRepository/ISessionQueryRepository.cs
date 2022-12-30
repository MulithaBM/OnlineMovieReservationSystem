using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.SessionRepository
{
    public interface ISessionQueryRepository : IRepository<Session>
    {
        Task<IEnumerable<Session>> Get();
        Task<Session> GetById(int id);
    }
}
