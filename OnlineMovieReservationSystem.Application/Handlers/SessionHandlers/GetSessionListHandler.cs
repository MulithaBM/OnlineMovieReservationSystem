using MediatR;
using OnlineMovieReservationSystem.Application.Queries.SessionQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class GetSessionListHandler : IRequestHandler<GetSessionListQuery, ServiceResponse<List<Session>>>
    {
        private readonly ISessionService _sessionService;

        public GetSessionListHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<List<Session>>> Handle(GetSessionListQuery request, CancellationToken cancellationToken)
        {
            return await _sessionService.GetAllSessions();
        }
    }
}
