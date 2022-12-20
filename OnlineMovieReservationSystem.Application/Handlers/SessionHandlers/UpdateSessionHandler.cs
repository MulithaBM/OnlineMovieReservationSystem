using MediatR;
using OnlineMovieReservationSystem.Application.Commands.SessionCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.SessionHandlers
{
    public class UpdateSessionHandler : IRequestHandler<UpdateSessionCommand, ServiceResponse<Session>>
    {
        private readonly ISessionService _sessionService;

        public UpdateSessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<ServiceResponse<Session>> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {
            return await _sessionService.UpdateSession(request.sessionChanges);
        }
    }
}
