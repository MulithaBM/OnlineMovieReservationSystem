using MediatR;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class AddVenueHandler : IRequestHandler<AddVenueCommand, ServiceResponse<List<Venue>>>
    {
        private readonly IVenueService _venueService;
        private readonly IUnitOfWork _unitOfWork;

        public AddVenueHandler(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<ServiceResponse<List<Venue>>> Handle(AddVenueCommand request, CancellationToken cancellationToken)
        {
            return await _venueService.AddVenue(request.Venue);
        }
    }
}
