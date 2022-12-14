using OnlineMovieReservationSystem.Dtos.Timetable;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Services.TimetableService
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
