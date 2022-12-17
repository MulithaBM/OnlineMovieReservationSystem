using OnlineMovieReservationSystem.Domain.Dtos.Session;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Services
{
    public interface ISessionService
    {
        Task<ServiceResponse<List<Session>>> GetAllSessions();
        Task<ServiceResponse<Session>> GetSessionById(int id);
        Task<ServiceResponse<List<Session>>> AddSession(SessionDto newSession);
        Task<ServiceResponse<Session>> DeleteSession(int id);
        Task<ServiceResponse<List<Session>>> AddMultipleSessions(List<SessionDto> newSessions);
    }
}
