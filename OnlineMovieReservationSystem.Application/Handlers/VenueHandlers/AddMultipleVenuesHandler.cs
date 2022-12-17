using MediatR;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class AddMultipleVenuesHandler : IRequestHandler<AddMultipleVenuesCommand, ServiceResponse<List<Venue>>>
    {
        private readonly IVenueService _venueService;

        public AddMultipleVenuesHandler(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<ServiceResponse<List<Venue>>> Handle(AddMultipleVenuesCommand request, CancellationToken cancellationToken)
        {
            return await _venueService.AddMultipleVenues(request.Venues);
        }
    }
}
