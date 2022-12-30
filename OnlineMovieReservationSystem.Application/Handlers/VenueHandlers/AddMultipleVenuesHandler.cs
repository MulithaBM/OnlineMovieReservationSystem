using MediatR;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class AddMultipleVenuesHandler : IRequestHandler<AddMultipleVenuesCommand, ServiceResponse<List<Venue>>>
    {
        private readonly IVenueService _venueService;
        private readonly IUnitOfWork _unitOfWork;

        public AddMultipleVenuesHandler(IVenueService venueService, IUnitOfWork unitOfWork)
        {
            _venueService = venueService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<Venue>>> Handle(AddMultipleVenuesCommand request, CancellationToken cancellationToken)
        {
            var venues = await _venueService.AddMultipleVenues(request.Venues);
            await _unitOfWork.SaveChangesAsync();
            return venues;
        }
    }
}
