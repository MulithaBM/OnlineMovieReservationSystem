using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly DataContext _context;

        public SessionService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Session>>> AddSession(Session newSession)
        {
            var response = new ServiceResponse<List<Session>>();

            try
            {
                var movie = await _context.Movies.FirstAsync(m => m.Id == newSession.Movie.Id);
                var venue = await _context.Venues.FirstAsync(v => v.Id == newSession.Venue.Id);

                Session session = new()
                {
                    Movie = movie,
                    Venue = venue
                };

                await _context.Sessions.AddAsync(session);
                await _context.SaveChangesAsync();

                response.Data = await _context.Sessions.ToListAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Session>>> AddMultipleSessions(List<Session> newSessions)
        {
            var response = new ServiceResponse<List<Session>>();

            try
            {
                var sessions = new List<Session>();

                foreach (var newSession in newSessions)
                {
                    var movie = await _context.Movies.FirstAsync(m => m.Id == newSession.Movie.Id);
                    var venue = await _context.Venues.FirstAsync(v => v.Id == newSession.Venue.Id);

                    Session session = new()
                    {
                        Movie = movie,
                        Venue = venue
                    };

                    sessions.Add(session);
                }

                await _context.Sessions.AddRangeAsync(sessions);
                await _context.SaveChangesAsync();

                response.Data = await _context.Sessions.ToListAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Session>> DeleteSession(int id)
        {
            var response = new ServiceResponse<Session>();

            try
            {
                var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);

                if(session == null)
                {
                    response.Success = false;
                    response.Message = "Session not found";

                    return response;
                }

                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();

                response.Data = session;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Session>>> GetAllSessions()
        {
            var response = new ServiceResponse<List<Session>>();

            try
            {
                var sessions = await _context.Sessions.ToListAsync();

                if(!sessions.Any())
                {
                    response.Success = false;
                    response.Message = "No sessions available";

                    return response;
                }

                response.Data = sessions;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Session>> GetSessionById(int id)
        {
            var response = new ServiceResponse<Session>();

            try
            {
                var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);

                if(session == null)
                {
                    response.Success = false;
                    response.Message = "Session not found";

                    return response;
                }

                response.Data = session;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
