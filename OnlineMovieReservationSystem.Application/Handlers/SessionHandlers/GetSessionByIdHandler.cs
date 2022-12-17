using MediatR;
using OnlineMovieReservationSystem.Application.Queries.SessionQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class GetSessionByIdHandler : IRequestHandler<GetSessionByIdQuery, ServiceResponse<Session>>
    {
        private readonly ISessionService _sessionService;

        public GetSessionByIdHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<Session>> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sessionService.GetSessionById(request.Id);
        }
    }
}
