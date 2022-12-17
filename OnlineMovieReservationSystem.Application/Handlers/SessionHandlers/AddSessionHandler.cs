using MediatR;
using OnlineMovieReservationSystem.Application.Commands.SessionCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class AddSessionHandler : IRequestHandler<AddSessionCommand, ServiceResponse<List<Session>>>
    {
        private readonly ISessionService _sessionService;

        public AddSessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<List<Session>>> Handle(AddSessionCommand request, CancellationToken cancellationToken)
        {
            return await _sessionService.AddSession(request.Session);
        }
    }
}
