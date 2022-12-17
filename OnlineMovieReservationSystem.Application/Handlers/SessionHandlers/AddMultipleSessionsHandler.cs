using MediatR;
using OnlineMovieReservationSystem.Application.Commands.SessionCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class AddMultipleSessionsHandler : IRequestHandler<AddMultipleSessionsCommand, ServiceResponse<List<Session>>>
    {
        private readonly ISessionService _sessionService;

        public AddMultipleSessionsHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<List<Session>>> Handle(AddMultipleSessionsCommand request, CancellationToken cancellationToken)
        {
            return await _sessionService.AddMultipleSessions(request.Sessions);
        }
    }
}
