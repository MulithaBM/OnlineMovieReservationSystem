using MediatR;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class DeleteVenueHandler : IRequestHandler<DeleteVenueCommand, ServiceResponse<Venue>>
    {
        private readonly IVenueService _venueService;

        public DeleteVenueHandler(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<ServiceResponse<Venue>> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
        {
            return await _venueService.DeleteVenue(request.Id);
        }
    }
}
