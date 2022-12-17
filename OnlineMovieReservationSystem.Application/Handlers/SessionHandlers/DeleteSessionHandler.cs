using MediatR;
using OnlineMovieReservationSystem.Application.Commands.SessionCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class DeleteSessionHandler : IRequestHandler<DeleteSessionCommand, ServiceResponse<Session>>
    {
        private readonly ISessionService _sessionService;

        public DeleteSessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<Session>> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            return await _sessionService.DeleteSession(request.Id);
        }
    }
}
